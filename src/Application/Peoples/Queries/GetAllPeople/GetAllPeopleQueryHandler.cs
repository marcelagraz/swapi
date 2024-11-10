using MediatR;
using SwApi.Application.Common.Repositories;
using SwApi.Application.Peoples.Queries.GetAllPeople;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.GetAllPeople;

public class GetAllPeopleQueryHandler(
    IPeopleRepository peopleRepository) :
    IRequestHandler<GetAllPeopleQuery, List<People>>
{
    private readonly IPeopleRepository peopleRepository = peopleRepository;

    public async Task<List<People>> Handle(GetAllPeopleQuery query, CancellationToken cancellationToken)
    {
        var peoples = await peopleRepository.FindAllAsync(query.PageNumber, query.PageSize, cancellationToken);

        return peoples;
    }
}
