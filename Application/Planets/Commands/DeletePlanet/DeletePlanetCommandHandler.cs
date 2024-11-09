using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.DeletePlanet;

public class DeletePlanetCommandHandler(
    IMapper mapper,
    IPlanetRepository planetRepository) :
    IRequestHandler<DeletePlanetCommand, Guid>
{
    private readonly IPlanetRepository planetRepository = planetRepository;

    public async Task<Guid> Handle(DeletePlanetCommand command, CancellationToken cancellationToken)
    {
        var planet = mapper.Map<Planet>(command);

        await planetRepository.DeleteAsync(planet, cancellationToken);

        return planet.Id;
    }
}
