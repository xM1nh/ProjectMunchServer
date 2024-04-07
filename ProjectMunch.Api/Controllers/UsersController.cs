using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectMunch.DTO.UsersApi;
using ProjectMunch.Models;

namespace ProjectMunch.Api.Controllers
{
    public class UsersController(UserManager<ApplicationUser> userManager) : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        [HttpGet("principal")]
        [Authorize]
        public async Task<
            Results<Ok<GetPrincipalUserResponseDto>, ForbidHttpResult>
        > GetPrincipalUser()
        {
            var userName = HttpContext
                .User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;

            if (string.IsNullOrEmpty(userName))
            {
                return TypedResults.Forbid();
            }

            var user = await _userManager.FindByNameAsync(userName!);
            var roles = await _userManager.GetRolesAsync(user!);

            return TypedResults.Ok(new GetPrincipalUserResponseDto(user!.UserName!, roles));
        }
    }
}
