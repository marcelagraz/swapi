using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Configurations;

public class FilmConfiguration : BaseConfiguration<Film>
{
    public override void Configure(EntityTypeBuilder<Film> builder)
    {
        base.Configure(builder);

        builder
            .Property(f => f.Title)
            .IsRequired();

        builder
            .Property(f => f.EpisodeId)
            .IsRequired();

        builder
            .Property(f => f.Director)
            .IsRequired();

        builder
            .Property(f => f.ReleaseDate)
            .IsRequired();

        builder
            .HasMany(f => f.Characters)
            .WithMany(c => c.Films);

        builder
            .HasMany(f => f.Planets)
            .WithMany(p => p.Films);
    }
}
