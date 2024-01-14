using Domain.Birds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Birds;

internal class BirdConfiguration : IEntityTypeConfiguration<Bird>
{
    /// <summary>
    /// TODO: Implement Unique Index on name, max length (name) of 1000 and required FK, with cascade on delete.
    /// </summary>
    public void Configure(EntityTypeBuilder<Bird> builder)
    {

    }
}