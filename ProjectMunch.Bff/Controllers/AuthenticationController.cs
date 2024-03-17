using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectMunch.DTO.Authentication;

namespace ProjectMunch.Bff.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController(ICacheService cacheService, AuthClient authClient)
        : ControllerBase
    {
        private readonly ICacheService _cacheService = cacheService;
        private readonly AuthClient _client = authClient;

        [HttpPost("/register")]
        public async Task<Results<Ok, UnauthorizedHttpResult>> Register(RegisterRequestDto request)
        {
            var response = await _client.RegisterAsync(request);

            if (!response)
            {
                return TypedResults.Unauthorized();
            }

            return TypedResults.Ok();
        }

        [HttpPost("/login")]
        public async Task<Results<SignInHttpResult, UnauthorizedHttpResult>> Login(
            LoginRequestDto request
        )
        {
            var tokens = await _client.LoginAsync(request);

            if (tokens is null)
            {
                return TypedResults.Unauthorized();
            }

            //_cacheService.SetData(request.UserName, tokens);

            List<Claim> claims =
            [
                new(ClaimTypes.Name, request.UserName),
                new("AccessToken", tokens.AccessToken),
            ];
            ClaimsIdentity identity =
                new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new(identity);

            return TypedResults.SignIn(principal);
        }

        [HttpDelete("/logout")]
        [Authorize]
        public async Task<Results<SignOutHttpResult, BadRequest>> Logout()
        {
            var userName = HttpContext
                .User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)
                ?.Value;

            var tokens = _cacheService.GetData<LoginResponseDto>(userName!);

            if (tokens is null)
            {
                return TypedResults.BadRequest();
            }

            var response = await _client.LogoutAsync(userName!, tokens.AccessToken);

            if (!response)
            {
                return TypedResults.BadRequest();
            }

            return TypedResults.SignOut();
        }

        [HttpPost("/refresh")]
        [Authorize]
        public async Task<Results<SignInHttpResult, BadRequest, UnauthorizedHttpResult>> Refresh()
        {
            var userName = HttpContext
                .User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)
                ?.Value;

            var tokens = _cacheService.GetData<LoginResponseDto>(userName!);

            if (tokens is null)
            {
                return TypedResults.BadRequest();
            }

            var response = await _client.RefreshAsync(userName!, tokens.RefreshToken);

            if (response is null)
            {
                return TypedResults.Unauthorized();
            }

            _cacheService.SetData(userName!, tokens);

            List<Claim> claims =
            [
                new(ClaimTypes.Name, userName!),
                new("AccessToken", tokens.AccessToken),
            ];
            ClaimsIdentity identity = new(claims);
            ClaimsPrincipal principal = new(identity);

            return TypedResults.SignIn(principal);
        }
    }
}
