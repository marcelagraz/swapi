using Ardalis.GuardClauses;
using FluentValidation;
using SwApi.Application.Common.Repositories;
using SwApi.Application.Peoples.Commands.UpdatePeople;
using SwApi.Domain.Entities;

namespace SwApi.Application.Films.Commands.UpdateFilm;

public class UpdatePeopleCommandValidator : AbstractValidator<UpdatePeopleCommand>
{
    private readonly IPeopleRepository _peopleRepository;
    private readonly IPlanetRepository _planetRepository;

    public UpdatePeopleCommandValidator(IPeopleRepository peopleRepository, IPlanetRepository planetRepository)
    {
        _peopleRepository = peopleRepository;
        _planetRepository = planetRepository;

        RuleFor(v => v.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .MustAsync(ExistInDatabase)
            .WithMessage("'People' must exist in database.");

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

        RuleFor(v => v.ConcurrencyStamp)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();
    }

    private Task<bool> ExistInDatabase(Guid? id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        return _peopleRepository.AnyAsync(id.Value, cancellationToken);
    }

    private Task<bool> PlanetExistInDatabase(Guid? planetId, CancellationToken cancellationToken)
    {
        Guard.Against.Null(planetId);
        return _planetRepository.AnyAsync(planetId.Value, cancellationToken);
    }
}
