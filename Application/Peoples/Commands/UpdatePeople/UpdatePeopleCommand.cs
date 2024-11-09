using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.UpdatePeople;

public record UpdatePeopleCommand : IRequest<People>
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public int? BirthYear { get; set; }

    public string? Gender { get; set; }

    public Guid? PlanetId { get; set; }
}
