using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.UpdatePlanet;

public record UpdatePlanetCommand : IRequest<Planet>
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public string? Gravity { get; set; }

    public string? Climate { get; set; }

    public List<int> Residents { get; set; } = [];

    public List<int> Films { get; set; } = [];

    public string? ConcurrencyStamp { get; set; }
}
