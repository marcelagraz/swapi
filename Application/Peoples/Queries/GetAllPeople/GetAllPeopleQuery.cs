using SwApi.Application.Common.Requests;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Queries.GetAllPeople;

public record GetAllPeopleQuery : GetAllQuery<People>
{
}
