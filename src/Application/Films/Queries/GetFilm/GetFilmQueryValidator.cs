using SwApi.Application.Common.Repositories;
using SwApi.Application.Common.Validators;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Queries.GetAllFilm;

public class GetFilmQueryValidator(IFilmRepository filmRepository) :
    GetQueryValidator<Film, IFilmRepository>(filmRepository)
{
}
