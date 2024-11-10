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
        RuleFor(v => v.PageNumber)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .GreaterThan(0);

        RuleFor(v => v.PageSize)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .GreaterThan(0);
    }
}
