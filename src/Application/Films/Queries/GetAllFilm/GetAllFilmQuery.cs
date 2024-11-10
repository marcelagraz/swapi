using SwApi.Application.Common.Requests;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Queries.GetAllFilm;

public record GetAllFilmQuery : GetAllQuery<Film>
{
}
