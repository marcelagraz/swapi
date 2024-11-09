using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.UpdateFilm;

public record UpdateFilmCommand : IRequest<Film>
{
    public Guid? Id { get; set; }

    public string? Title { get; set; }

    public int? Episode { get; set; }

    public string? Director { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public List<int> Characters { get; set; } = [];

    public List<int> Planets { get; set; } = [];
}
