using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.GetAllPlanet;

public record GetAllPlanetQuery : IRequest<List<Planet>>
{
    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }
}
