using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Configurations;

public class PlanetConfiguration : Configuration<Planet>
{
    public override void Configure(EntityTypeBuilder<Planet> builder)
    {
        base.Configure(builder);

        builder
            .Property(planet => planet.Name)
            .IsRequired();

        builder
            .Property(planet => planet.Gravity)
            .IsRequired();

        builder
            .Property(planet => planet.Climate)
            .IsRequired();

        builder
            .HasMany(planet => planet.Films)
            .WithMany(film => film.Planets);
    }
}
