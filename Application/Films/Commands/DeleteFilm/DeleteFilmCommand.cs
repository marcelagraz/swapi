using MediatR;

namespace SwApi.Application.Films.Commands.DeleteFilm;

public record DeleteFilmCommand : IRequest<Guid>
{
    public string? Name { get; set; }

    public int? BirthYear { get; set; }

    public string? Gender { get; set; }

    public Guid? PlanetId { get; set; }
}
