using MediatR;

namespace SwApi.Application.Planets.Commands.UpdatePlanet;

public record UpdatePlanetCommand : IRequest<Guid>
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public int? BirthYear { get; set; }

    public string? Gender { get; set; }

    public Guid? PlanetId { get; set; }
}
