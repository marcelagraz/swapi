using MediatR;

namespace SwApi.Application.Peoples.Commands.DeletePeople;

public record DeletePeopleCommand : IRequest<Guid>
{
    public string? Name { get; set; }

    public int? BirthYear { get; set; }

    public string? Gender { get; set; }

    public Guid? PlanetId { get; set; }
}
