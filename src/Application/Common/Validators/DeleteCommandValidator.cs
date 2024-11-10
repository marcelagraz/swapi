using Ardalis.GuardClauses;
using FluentValidation;
using SwApi.Application.Common.Repositories;
using SwApi.Application.Common.Requests;
using SwApi.Domain.Common;

namespace SwApi.Application.Common.Validators;

public abstract class DeleteCommandValidator<TEntity, TRepository, TRequest> : AbstractValidator<TRequest>
    where TEntity : BaseEntity
    where TRepository : IRepository<TEntity>
    where TRequest : DeleteCommand
{
    private readonly TRepository _repository;

    public DeleteCommandValidator(TRepository repository)
    {
        _repository = repository;

        RuleFor(c => c.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .MustAsync(ExistInDatabase)
            .WithMessage($"'{typeof(TEntity).Name}' with {{PropertyName}} {{PropertyValue}} must exist in database.");

        RuleFor(c => c.ConcurrencyStamp)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();
    }

    private Task<bool> ExistInDatabase(Guid? id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        return _repository.AnyAsync(id.Value, cancellationToken);
    }
}
