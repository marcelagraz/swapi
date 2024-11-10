using Microsoft.EntityFrameworkCore;
using SwApi.Domain.Common;
using System.Linq.Expressions;

namespace SwApi.Infrastructure.Persistence.Common;

public class Repository<TEntity>(DbContext dbContext) where TEntity : BaseEntity
{
    protected DbContext DbContext { get; } = dbContext;

    public Task<TEntity?> FindAsync(
        Guid id,
        bool noTracking = default,
        Expression<Func<TEntity, object?>>[]? includes = default,
        CancellationToken cancellationToken = default)
    {
        includes ??= [];
        IQueryable<TEntity> queryable = DbContext.Set<TEntity>();

        if (includes.Any())
        {
            foreach (Expression<Func<TEntity, object?>>? include in includes)
            {
                queryable = queryable.Include(include);
            }
        }

        if (noTracking)
            queryable = queryable.AsNoTracking();

        return queryable.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public Task<List<TEntity>> FindAllAsync(
        int? pageNumber = default,
        int? pageSize = default,
        bool noTracking = default,
        Expression<Func<TEntity, bool>>? where = default,
        Expression<Func<TEntity, object?>>? orderBy = default,
        Expression<Func<TEntity, object?>>[]? includes = default,
        CancellationToken cancellationToken = default)
    {
        includes ??= [];
        IQueryable<TEntity>? queryable = DbContext.Set<TEntity>();

        if (includes.Any())
        {
            foreach (Expression<Func<TEntity, object?>>? include in includes)
                queryable = queryable!.Include(include);
        }

        if (where is not null)
            queryable = queryable.Where(where);

        if (orderBy is not null)
            queryable = queryable.OrderBy(orderBy);

        if (noTracking)
            queryable = queryable.AsNoTracking();

        if (pageSize is not null && pageNumber is not null)
        {
            queryable = queryable
                .Skip((pageNumber.Value - 1) * pageSize.Value)
                .Take(pageSize.Value);
        }

        return queryable.ToListAsync(cancellationToken);
    }

    public virtual TEntity Add(TEntity entity)
    {
        return DbContext
            .Add(entity)
            .Entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        return DbContext
            .Set<TEntity>()
            .Update(entity)
            .Entity;
    }

    public void Remove(TEntity entity)
    {
        DbContext
            .Set<TEntity>()
            .Remove(entity);
    }

    public Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return DbContext
            .Set<TEntity>()
            .AnyAsync(entity => entity.Id == id, cancellationToken);
    }
}
