using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Configurations;

public class PeopleConfiguration : Configuration<People>
{
    public override void Configure(EntityTypeBuilder<People> builder)
    {
        base.Configure(builder);

        builder
            .Property(people => people.Name)
            .IsRequired();

        builder
            .Property(people => people.BirthYear)
            .IsRequired();

        builder
            .Property(people => people.Gender)
            .IsRequired();

        builder
            .HasMany(character => character.Films)
            .WithMany(film => film.Characters);

        builder
            .HasOne(resident => resident.Planet)
            .WithMany(planet => planet.Residents)
            .HasForeignKey(planet => planet.PlanetId);
    }
}
