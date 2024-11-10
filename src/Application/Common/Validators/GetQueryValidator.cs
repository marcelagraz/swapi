using Ardalis.GuardClauses;
using FluentValidation;
using SwApi.Application.Common.Repositories;
using SwApi.Application.Films.Queries.GetFilm;
using SwApi.Domain.Common;

namespace SwApi.Application.Common.Validators;

public abstract class GetQueryValidator<TEntity, TRepository> : AbstractValidator<GetQuery<TEntity>>
    where TEntity : BaseEntity
    where TRepository : IRepository<TEntity>
{
    private readonly TRepository _repository;

    public GetQueryValidator(TRepository repository)
    {
        _repository = repository;

        RuleFor(v => v.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .MustAsync(ExistInDatabase)
            .WithMessage($"'{typeof(TEntity).Name}' with {{PropertyName}} {{PropertyValue}} must exist in database.");
    }

    private Task<bool> ExistInDatabase(Guid? id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        return _repository.AnyAsync(id.Value, cancellationToken);
    }
}
