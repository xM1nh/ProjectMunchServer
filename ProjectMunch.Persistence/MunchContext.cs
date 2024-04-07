using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectMunch.Models;

namespace ProjectMunch.Persistence
{
    public class MunchContext(DbContextOptions options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<PointOfInterest> PointOfInterests { get; set; }
        public DbSet<Save> Saves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new PointOfInterestConfiguration().Configure(modelBuilder.Entity<PointOfInterest>());

            SeedUsers(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUserRoles(modelBuilder);
        }

        private readonly string AdminUserId = Guid.NewGuid().ToString();
        private readonly string VerifiedUserId = Guid.NewGuid().ToString();
        private readonly string UserId = Guid.NewGuid().ToString();

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var admin = new ApplicationUser()
            {
                Id = AdminUserId,
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var verified = new ApplicationUser()
            {
                Id = VerifiedUserId,
                Email = "verified@example.com",
                NormalizedEmail = "VERIFIED@EXAMPLE.COM",
                UserName = "verified",
                NormalizedUserName = "VERIFIED",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var user = new ApplicationUser()
            {
                Id = UserId,
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                UserName = "user",
                NormalizedUserName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var hasher = new PasswordHasher<ApplicationUser>();

            admin.PasswordHash = hasher.HashPassword(admin, "P@ssw0rd");
            verified.PasswordHash = hasher.HashPassword(verified, "P@ssw0rd");
            user.PasswordHash = hasher.HashPassword(user, "P@ssw0rd");

            modelBuilder.Entity<ApplicationUser>().HasData([admin, verified, user]);
        }

        private readonly string VerifiedRoleId = Guid.NewGuid().ToString();
        private readonly string AdminRoleId = Guid.NewGuid().ToString();
        private readonly string UserRoleId = Guid.NewGuid().ToString();

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<IdentityRole>()
                .HasData(
                    [
                        new IdentityRole
                        {
                            Id = VerifiedRoleId,
                            Name = "Verified",
                            NormalizedName = "VERIFIED",
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                        },
                        new IdentityRole
                        {
                            Id = AdminRoleId,
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                        },
                        new IdentityRole
                        {
                            Id = UserRoleId,
                            Name = "User",
                            NormalizedName = "USER",
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                        },
                    ]
                );
        }

        private void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<IdentityUserRole<string>>()
                .HasData(
                    [
                        new IdentityUserRole<string>() { RoleId = UserRoleId, UserId = UserId },
                        new IdentityUserRole<string>()
                        {
                            RoleId = VerifiedRoleId,
                            UserId = VerifiedUserId
                        },
                        new IdentityUserRole<string>()
                        {
                            RoleId = UserRoleId,
                            UserId = VerifiedUserId
                        },
                        new IdentityUserRole<string>()
                        {
                            RoleId = AdminRoleId,
                            UserId = AdminUserId
                        },
                        new IdentityUserRole<string>()
                        {
                            RoleId = VerifiedRoleId,
                            UserId = AdminUserId
                        },
                        new IdentityUserRole<string>() { RoleId = UserRoleId, UserId = AdminUserId }
                    ]
                );
        }
    }
}
