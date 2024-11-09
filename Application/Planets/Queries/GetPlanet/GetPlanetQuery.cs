using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Queries.GetPlanet;

public record GetPlanetQuery : IRequest<Planet?>
{
    public Guid? Id { get; set; }
}
