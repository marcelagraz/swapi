using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.CreatePlanet;

public class CreatePlanetCommandHandler(
    IMapper mapper,
    IPlanetRepository planetRepository) :
    IRequestHandler<CreatePlanetCommand, Guid>
{
    private readonly IPlanetRepository planetRepository = planetRepository;

    public async Task<Guid> Handle(CreatePlanetCommand command, CancellationToken cancellationToken)
    {
        var planet = mapper.Map<Planet>(command);

        await planetRepository.AddAsync(planet, cancellationToken);

        return planet.Id;
    }
}
