using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.CreatePlanet;

public record CreatePlanetCommand : IRequest<Planet>
{
    public string? Name { get; set; }

    public string? Gravity { get; set; }

    public string? Climate { get; set; }

    public List<int> Residents { get; set; } = [];

    public List<int> Films { get; set; } = [];
}
