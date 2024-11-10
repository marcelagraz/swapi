using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.CreatePlanet;

public class CreatePlanetCommandHandler(
    IMapper mapper,
    IPlanetRepository planetRepository,
    TimeProvider timeProvider) :
    IRequestHandler<CreatePlanetCommand, Planet>
{
    private readonly IPlanetRepository _planetRepository = planetRepository;
    private readonly TimeProvider _timeProvider = timeProvider;

    public async Task<Planet> Handle(CreatePlanetCommand command, CancellationToken cancellationToken)
    {
        var planet = mapper.Map<Planet>(command);

        var utcNow = _timeProvider.GetUtcNow().UtcDateTime.ToString("o");

        planet.Created = utcNow;
        planet.Edited = utcNow;

        await _planetRepository.AddAsync(planet, cancellationToken);

        return planet;
    }
}
