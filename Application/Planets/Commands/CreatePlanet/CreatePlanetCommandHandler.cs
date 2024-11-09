using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.CreatePlanet;

public class CreatePlanetCommandHandler(
    IMapper mapper,
    IPlanetRepository planetRepository) :
    IRequestHandler<CreatePlanetCommand, Planet>
{
    private readonly IPlanetRepository planetRepository = planetRepository;

    public async Task<Planet> Handle(CreatePlanetCommand command, CancellationToken cancellationToken)
    {
        var planet = mapper.Map<Planet>(command);

        await planetRepository.AddAsync(planet, cancellationToken);

        return planet;
    }
}
