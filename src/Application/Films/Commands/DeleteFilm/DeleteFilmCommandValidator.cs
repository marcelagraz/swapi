using SwApi.Application.Common.Repositories;
using SwApi.Application.Common.Validators;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.DeleteFilm;

public class DeleteFilmCommandValidator(IFilmRepository filmRepository) :
    DeleteCommandValidator<Film, IFilmRepository, DeleteFilmCommand>(filmRepository)
{
}
