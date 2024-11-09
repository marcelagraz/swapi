using MediatR;

namespace SwApi.Application.Peoples.Commands.CreatePeople;

public record CreatePeopleCommand : IRequest<Guid>
{
    public string? Name { get; set; }

    public int? BirthYear { get; set; }

    public string? Gender { get; set; }

    public Guid? PlanetId { get; set; }
}
