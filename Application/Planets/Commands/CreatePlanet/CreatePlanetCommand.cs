using MediatR;

namespace SwApi.Application.Planets.Commands.CreatePlanet;

public record CreatePlanetCommand : IRequest<Guid>
{
    public string? Title { get; set; }

    public int? EpisodeId { get; set; }

    public string? Director { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public List<int> Characters { get; set; } = [];

    public List<int> Planets { get; set; } = [];
}
