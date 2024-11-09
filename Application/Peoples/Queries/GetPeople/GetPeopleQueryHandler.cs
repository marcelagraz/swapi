using Ardalis.GuardClauses;
using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Application.Peoples.Queries.GetPeople;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.GetPeople;

public class GetPeopleQueryHandler(
    IPeopleRepository peopleRepository) :
    IRequestHandler<GetPeopleQuery, People?>
{
    private readonly IPeopleRepository _peopleRepository = peopleRepository;

    public async Task<People?> Handle(GetPeopleQuery query, CancellationToken cancellationToken)
    {
        Guard.Against.Null(query.Id);

        var people = await _peopleRepository.FindAsync(query.Id.Value, cancellationToken);

        return people;
    }
}
