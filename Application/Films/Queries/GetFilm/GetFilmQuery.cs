using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.GetFilm;

public record GetFilmQuery : IRequest<Film?>
{
    public Guid? Id { get; set; }
}
