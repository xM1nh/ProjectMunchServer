using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectMunch.DTO.Authentication;
using ProjectMunch.Models;
using TodoApi;

namespace ProjectMunch.Api.Controllers
{
    public class AuthenticationController(
        UserManager<ApplicationUser> userManager,
        ITokenService tokenService
    ) : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;

        private const string TOKEN_LOGIN_PROVIDER = "Local";

        [HttpPost("register")]
        public async Task<Results<Created, ValidationProblem>> Register(RegisterRequestDto request)
        {
            var result = await _userManager.CreateAsync(
                new() { UserName = request.UserName, Email = request.Email },
                request.Password
            );

            if (result.Succeeded)
            {
                return TypedResults.Created();
            }

            return TypedResults.ValidationProblem(
                result.Errors.ToDictionary(e => e.Code, e => new[] { e.Description })
            );
        }

        [HttpPost("login")]
        public async Task<Results<Ok<LoginResponseDto>, UnauthorizedHttpResult>> Login(
            LoginRequestDto request
        )
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return TypedResults.Unauthorized();
            }

            var roles = (await _userManager.GetRolesAsync(user)).ToArray();

            var refreshToken = _tokenService.GenerateRefreshToken(user.UserName!, roles);
            var accessToken = _tokenService.GenerateAccessToken(user.UserName!, roles);

            await _userManager.SetAuthenticationTokenAsync(
                user,
                TOKEN_LOGIN_PROVIDER,
                "RefreshToken",
                refreshToken
            );

            return TypedResults.Ok(new LoginResponseDto(accessToken, refreshToken));
        }

        [HttpDelete("logout")]
        [Authorize]
        public async Task<Results<Ok, BadRequest>> Logout()
        {
            var userName = HttpContext
                .User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)
                ?.Value;
            var user = await _userManager.FindByNameAsync(userName!);

            if (user is null)
            {
                return TypedResults.BadRequest();
            }

            await _userManager.RemoveAuthenticationTokenAsync(
                user!,
                TOKEN_LOGIN_PROVIDER,
                "RefreshToken"
            );

            return TypedResults.Ok();
        }

        [HttpPost("refresh")]
        [Authorize]
        public async Task<
            Results<Ok<RefreshResponseDto>, ForbidHttpResult, UnauthorizedHttpResult>
        > Refresh()
        {
            var userName = HttpContext
                .User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)
                ?.Value;
            var user = await _userManager.FindByNameAsync(userName!);
            var token = HttpContext.Request.Headers.Authorization;

            var decodedToken = _tokenService.ReadToken(token!);

            //Reuse Detection
            if (user is null)
            {
                var existingUser = await _userManager.FindByNameAsync(decodedToken.Payload.Sub);
                await _userManager.RemoveAuthenticationTokenAsync(
                    existingUser!,
                    TOKEN_LOGIN_PROVIDER,
                    "RefreshToken"
                );

                return TypedResults.Forbid();
            }

            if (
                token
                != await _userManager.GetAuthenticationTokenAsync(
                    user,
                    TOKEN_LOGIN_PROVIDER,
                    "RefreshToken"
                )
            )
            {
                return TypedResults.Unauthorized();
            }

            var roles = (await _userManager.GetRolesAsync(user)).ToArray();

            var newRefreshToken = _tokenService.GenerateRefreshToken(user.UserName!, roles);
            var accessToken = _tokenService.GenerateAccessToken(user.UserName!, roles);

            return TypedResults.Ok(new RefreshResponseDto(accessToken, newRefreshToken));
        }
    }
}
