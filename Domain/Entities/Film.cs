using SwApi.Domain.Common;

namespace SwApi.Domain.Entities;

public class Film : BaseEntity
{
    public required string Title { get; set; }

    public required int EpisodeId { get; set; }

    public required string OpeningCrawl { get; set; }

    public required string Director { get; set; }

    public required string Producer { get; set; }

    public required DateOnly ReleaseDate { get; set; }

    public List<Specie> Species { get; set; } = [];

    public List<Starship> Starships { get; set; } = [];

    public List<Vehicle> Vehicles { get; set; } = [];

    public List<People> Characters { get; set; } = [];

    public List<Planet> Planets { get; set; } = [];
}
