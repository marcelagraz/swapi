using MediatR;
using SwApi.Domain.Common;

namespace SwApi.Application.Common.Requests;

public abstract record GetAllQuery<TEntity> : IRequest<List<TEntity>> where TEntity : BaseEntity
{
    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }
}
