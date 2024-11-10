using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.UpdatePlanet;

public class UpdatePlanetCommandHandler(
    IMapper mapper,
    IPlanetRepository planetRepository,
    TimeProvider timeProvider) :
    IRequestHandler<UpdatePlanetCommand, Planet>
{
    private readonly IPlanetRepository _planetRepository = planetRepository;
    private readonly TimeProvider _timeProvider = timeProvider;

    public async Task<Planet> Handle(UpdatePlanetCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command.Id);

        var planet = await _planetRepository.FindAsync(command.Id.Value, cancellationToken);

        Guard.Against.Null(planet);

        mapper.Map(command, planet);

        planet.Edited = _timeProvider.GetUtcNow().UtcDateTime.ToString("o");

        await _planetRepository.UpdateAsync(planet, cancellationToken);

        return planet;
    }
}
