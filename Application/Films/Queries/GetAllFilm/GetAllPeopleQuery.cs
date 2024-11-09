using MediatR;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.GetAllFilm;

public record GetAllFilmQuery : IRequest<List<Film>>
{
    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }
}
