using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Configurations;

public class PlanetConfiguration : BaseConfiguration<Planet>
{
    public override void Configure(EntityTypeBuilder<Planet> builder)
    {
        base.Configure(builder);

        builder
            .Property(p => p.Name)
            .IsRequired();

        builder
            .Property(p => p.Gravity)
            .IsRequired();

        builder
            .Property(p => p.Climate)
            .IsRequired();

        builder
            .HasMany(p => p.Films)
            .WithMany(f => f.Planets);
    }
}
