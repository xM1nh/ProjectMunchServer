using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectMunch.Models;

namespace ProjectMunch.Persistence
{
    internal class PointOfInterestConfiguration : IEntityTypeConfiguration<PointOfInterest>
    {
        public void Configure(EntityTypeBuilder<PointOfInterest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).HasDefaultValue(string.Empty);
            builder.Property(x => x.Coordinate).HasColumnType("geography (point)").IsRequired();
        }
    }
}
