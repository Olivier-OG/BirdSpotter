using Domain.Birds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Birds;

internal class BirdConfiguration : IEntityTypeConfiguration<Bird>
{
    public void Configure(EntityTypeBuilder<Bird> builder)
    {
        builder.HasIndex(b => b.Name).IsUnique();
        builder.Property(b => b.Name).HasMaxLength(1000);

        builder
            .HasMany(b => b.Spots)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}