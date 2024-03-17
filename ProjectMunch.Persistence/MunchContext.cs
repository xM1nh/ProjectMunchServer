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

            //Data Seeding
            modelBuilder
                .Entity<IdentityRole>()
                .HasData(
                    [
                        new IdentityRole
                        {
                            Name = "VerifiedUser",
                            NormalizedName = "VERIFIEDUSER",
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                        },
                        new IdentityRole
                        {
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                        }
                    ]
                );
        }
    }
}
