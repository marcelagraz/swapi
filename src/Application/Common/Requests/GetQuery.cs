using MediatR;
using SwApi.Domain.Common;

namespace SwApi.Application.Films.Queries.GetFilm;

public abstract record GetQuery<TEntity> : IRequest<TEntity?> where TEntity : BaseEntity
{
    public Guid? Id { get; set; }
}
