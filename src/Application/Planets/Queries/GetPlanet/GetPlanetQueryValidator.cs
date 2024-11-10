using SwApi.Application.Common.Repositories;
using SwApi.Application.Common.Validators;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Queries.GetPlanet;

public class GetPlanetQueryValidator(IPlanetRepository planetRepository) : GetQueryValidator<Planet, IPlanetRepository>(planetRepository)
{
}
