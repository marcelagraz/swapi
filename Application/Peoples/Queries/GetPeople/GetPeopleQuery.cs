using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Queries.GetPeople;

public record GetPeopleQuery : IRequest<People?>
{
    public Guid? Id { get; set; }
}
