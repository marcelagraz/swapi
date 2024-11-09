using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.GetAllPeople;

public record GetAllPeopleQuery : IRequest<List<People>>
{
    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }
}
