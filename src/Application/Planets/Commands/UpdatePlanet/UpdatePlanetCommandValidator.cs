﻿using Ardalis.GuardClauses;
using FluentValidation;
using SwApi.Application.Common.Repositories;

namespace SwApi.Application.Planets.Commands.UpdatePlanet;

public class UpdatePlanetCommandValidator : AbstractValidator<UpdatePlanetCommand>
{
    private readonly IPlanetRepository _planetRepository;

    public UpdatePlanetCommandValidator(IPlanetRepository planetRepository)
    {
        _planetRepository = planetRepository;

        RuleFor(v => v.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .MustAsync(ExistInDatabase)
            .WithMessage("'Planet' must exist in database.");

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

        RuleFor(v => v.ConcurrencyStamp)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();
    }

    private Task<bool> ExistInDatabase(Guid? id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        return _planetRepository.AnyAsync(id.Value, cancellationToken);
    }
}
