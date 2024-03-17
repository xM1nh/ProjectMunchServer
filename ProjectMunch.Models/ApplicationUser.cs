using Microsoft.AspNetCore.Identity;

namespace ProjectMunch.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Save> Saves { get; } = [];
    }
}
