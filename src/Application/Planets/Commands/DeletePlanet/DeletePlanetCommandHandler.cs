using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using SwApi.Application.Common.Repositories;

namespace SwApi.Application.Planets.Commands.DeletePlanet;

public class DeletePlanetCommandHandler(
    IMapper mapper,
    IPlanetRepository planetRepository) :
    IRequestHandler<DeletePlanetCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IPlanetRepository _planetRepository = planetRepository;

    public async Task Handle(DeletePlanetCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command.Id);

        var planet = await _planetRepository.FindAsync(command.Id.Value, cancellationToken);

        Guard.Against.Null(planet);

        _mapper.Map(command, planet);

        await _planetRepository.DeleteAsync(planet, cancellationToken);
    }
}
