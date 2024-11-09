using SwApi.Application.Common.Repositories;
using SwApi.Application.Common.Validators;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.DeletePlanet;

public class DeletePlanetCommandValidator(IPlanetRepository planetRepository) : DeleteCommandValidator<Planet, IPlanetRepository>(planetRepository)
{
}
