using SwApi.Application.Common.Requests;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Queries.GetAllPlanet;

public record GetAllPlanetQuery : GetAllQuery<Planet>
{
}
