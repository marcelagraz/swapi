using Ardalis.GuardClauses;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Queries.GetPlanet;

public class GetPlanetQueryHandler(
    IPlanetRepository planetRepository) :
    IRequestHandler<GetPlanetQuery, Planet?>
{
    private readonly IPlanetRepository planetRepository = planetRepository;

    public async Task<Planet?> Handle(GetPlanetQuery query, CancellationToken cancellationToken)
    {
        Guard.Against.Null(query.Id);

        var planet = await planetRepository.FindAsync(query.Id.Value, cancellationToken);

        return planet;
    }
}
