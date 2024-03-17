using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectMunch.DTO.User;
using ProjectMunch.Models;

namespace ProjectMunch.Api.Controllers
{
    public class UserController(UserManager<ApplicationUser> userManager) : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        [HttpGet("{userName}")]
        public async Task<Results<Ok<GetUserResponseDto>, NotFound>> GetUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user is null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(new GetUserResponseDto(user!.UserName!));
        }

        [HttpGet("principal")]
        [Authorize]
        public async Task<
            Results<Ok<GetPrincipalUserResponseDto>, ForbidHttpResult>
        > GetPrincipalUser()
        {
            var userName = HttpContext.User.Identity!.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                return TypedResults.Forbid();
            }

            var user = await _userManager.FindByNameAsync(userName!);
            var roles = await _userManager.GetRolesAsync(user!);

            return TypedResults.Ok(new GetPrincipalUserResponseDto(user!.UserName!, roles));
        }
    }
}
