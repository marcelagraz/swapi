using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Configurations;

public class FilmConfiguration : Configuration<Film>
{
    public override void Configure(EntityTypeBuilder<Film> builder)
    {
        base.Configure(builder);

        builder
            .Property(film => film.Title)
            .IsRequired();

        builder
            .Property(film => film.Episode)
            .IsRequired();

        builder
            .Property(film => film.Director)
            .IsRequired();

        builder
            .Property(film => film.ReleaseDate)
            .IsRequired();

        builder
            .HasMany(film => film.Characters)
            .WithMany(character => character.Films);

        builder
            .HasMany(film => film.Planets)
            .WithMany(planet => planet.Films);
    }
}
