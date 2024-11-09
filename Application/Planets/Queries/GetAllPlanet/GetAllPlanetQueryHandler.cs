using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Planets.Commands.GetAllPlanet;

public class GetAllPlanetQueryHandler(
    IPlanetRepository planetRepository) :
    IRequestHandler<GetAllPlanetQuery, List<Planet>>
{
    private readonly IPlanetRepository planetRepository = planetRepository;

    public async Task<List<Planet>> Handle(GetAllPlanetQuery query, CancellationToken cancellationToken)
    {
        var planets = await planetRepository.FindAllAsync(query.PageNumber, query.PageSize, cancellationToken);

        return planets;
    }
}
