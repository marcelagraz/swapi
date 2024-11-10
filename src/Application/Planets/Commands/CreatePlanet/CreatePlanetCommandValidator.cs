using FluentValidation;

namespace SwApi.Application.Planets.Commands.CreatePlanet;

public class CreatePlanetCommandValidator : AbstractValidator<CreatePlanetCommand>
{
    public CreatePlanetCommandValidator()
    {
        RuleFor(v => v.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Gravity)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Climate)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Residents)
            .NotEmpty();

        RuleFor(v => v.Films)
            .NotEmpty();
    }
}
