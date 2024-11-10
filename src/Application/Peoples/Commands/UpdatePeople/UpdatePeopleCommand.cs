using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.UpdatePeople;

public record UpdatePeopleCommand : IRequest<People>
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public string? BirthYear { get; set; }

    public string? Gender { get; set; }

    public Guid? HomeworldId { get; set; }

    public string? ConcurrencyStamp { get; set; }
}
