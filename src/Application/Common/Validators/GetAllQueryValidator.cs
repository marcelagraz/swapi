using FluentValidation;
using SwApi.Application.Common.Requests;
using SwApi.Domain.Common;

namespace SwApi.Application.Common.Validators;

public abstract class GetAllQueryValidator<TRequest, TEntity> : AbstractValidator<TRequest>
    where TRequest : GetAllQuery<TEntity>
    where TEntity : BaseEntity
{
    public GetAllQueryValidator()
    {
        RuleFor(q => q.PageNumber)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .GreaterThan(0);

        RuleFor(q => q.PageSize)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .GreaterThan(0);
    }
}
