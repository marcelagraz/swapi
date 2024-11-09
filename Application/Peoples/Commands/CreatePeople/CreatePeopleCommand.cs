using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.CreatePeople;

public record CreatePeopleCommand : IRequest<People>
{
    public string? Name { get; set; }

    public int? BirthYear { get; set; }

    public string? Gender { get; set; }

    public Guid? PlanetId { get; set; }
}
