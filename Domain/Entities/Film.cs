using SwApi.Domain.Common;

namespace SwApi.Domain.Entities;

public class Film : BaseEntity
{
    public string? Title { get; set; }

    public int? EpisodeId { get; set; }

    public string? Director { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public List<People> Characters { get; set; } = [];

    public List<Planet> Planets { get; set; } = [];
}
