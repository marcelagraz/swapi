using FluentValidation;

namespace SwApi.Application.Films.Commands.CreateFilm;

public class CreateFilmCommandValidator : AbstractValidator<CreateFilmCommand>
{
    public CreateFilmCommandValidator()
    {
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
}
