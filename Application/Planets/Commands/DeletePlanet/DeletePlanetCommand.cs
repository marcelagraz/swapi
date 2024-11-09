using MediatR;

namespace SwApi.Application.Planets.Commands.DeletePlanet;

public record DeletePlanetCommand : IRequest<Guid>
{
    public string? Name { get; set; }

    public int? BirthYear { get; set; }

    public string? Gender { get; set; }

    public Guid? PlanetId { get; set; }
}
