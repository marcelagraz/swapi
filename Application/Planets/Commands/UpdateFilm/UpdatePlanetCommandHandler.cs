using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.UpdatePlanet;

public class UpdatePlanetCommandHandler(
    IMapper mapper,
    IPlanetRepository planetRepository) :
    IRequestHandler<UpdatePlanetCommand, Guid>
{
    private readonly IPlanetRepository planetRepository = planetRepository;

    public async Task<Guid> Handle(UpdatePlanetCommand command, CancellationToken cancellationToken)
    {
        var planet = mapper.Map<Planet>(command);

        await planetRepository.UpdateAsync(planet, cancellationToken);

        return planet.Id;
    }
}
