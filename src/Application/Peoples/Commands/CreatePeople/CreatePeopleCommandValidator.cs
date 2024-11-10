using Ardalis.GuardClauses;
using FluentValidation;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;

namespace SwApi.Application.Peoples.Commands.CreatePeople;

public class CreatePeopleCommandValidator : AbstractValidator<CreatePeopleCommand>
{
    private readonly IPlanetRepository _planetRepository;

    public CreatePeopleCommandValidator(IPlanetRepository planetRepository)
    {
        _planetRepository = planetRepository;

        RuleFor(v => v.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.BirthYear)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Gender)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.HomeworldId)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .MustAsync(PlanetExistInDatabase)
            .WithMessage($"'{nameof(Planet)}' with {{PropertyName}} {{PropertyValue}} must exist in database.");
    }

    private Task<bool> PlanetExistInDatabase(Guid? planetId, CancellationToken cancellationToken)
    {
        Guard.Against.Null(planetId);
        return _planetRepository.AnyAsync(planetId.Value, cancellationToken);
    }
}
