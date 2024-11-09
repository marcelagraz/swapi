using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Configurations;

public class PeopleConfiguration : BaseConfiguration<People>
{
    public override void Configure(EntityTypeBuilder<People> builder)
    {
        base.Configure(builder);

        builder
            .Property(p => p.Name)
            .IsRequired();

        builder
            .Property(p => p.BirthYear)
            .IsRequired();

        builder
            .Property(p => p.Gender)
            .IsRequired();

        builder
            .HasMany(p => p.Films)
            .WithMany(f => f.Characters);

        builder
            .HasOne(p => p.Planet)
            .WithMany(p => p.Residents)
            .HasForeignKey(p => p.PlanetId);
    }
}
