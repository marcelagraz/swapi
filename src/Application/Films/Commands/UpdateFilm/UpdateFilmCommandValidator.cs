using Ardalis.GuardClauses;
using FluentValidation;
using SwApi.Application.Common.Repositories;

namespace SwApi.Application.Films.Commands.UpdateFilm;

public class UpdateFilmCommandValidator : AbstractValidator<UpdateFilmCommand>
{
    private readonly IFilmRepository _filmRepository;

    public UpdateFilmCommandValidator(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;

        RuleFor(v => v.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .MustAsync(ExistInDatabase)
            .WithMessage("Film must exist in database.");

        RuleFor(v => v.Title)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Episode)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Director)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.ReleaseDate)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Characters)
            .NotEmpty();

        RuleFor(v => v.Characters)
            .NotEmpty();
    }

    private Task<bool> ExistInDatabase(Guid? id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        return _filmRepository.AnyAsync(id.Value, cancellationToken);
    }
}
