using Microsoft.EntityFrameworkCore;
using SwApi.Domain.Common;
using System.Linq.Expressions;

namespace SwApi.Infrastructure.Persistence.Repositories;

public class Repository<TEntity>(DbContext dbContext) where TEntity: BaseEntity, new()
{
    private readonly DbContext _dbContext = dbContext;

    public Task<TEntity?> FindAsync(
        Guid id,
        bool noTracking = default,
        Expression<Func<TEntity, object?>>[]? includes = default,
        CancellationToken cancellationToken = default)
    {
        includes ??= [];
        IQueryable<TEntity> queryable = _dbContext.Set<TEntity>();

        if (includes.Any())
        {
            foreach (Expression<Func<TEntity, object?>>? include in includes)
            {
                queryable = queryable.Include(include);
            }
        }

        if (noTracking)
            queryable = queryable.AsNoTracking();

        return queryable.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IList<TEntity>> FindAllAsync(
        bool noTracking = default,
        Expression<Func<TEntity, bool>>? where = default,
        Expression<Func<TEntity, object?>>? orderBy = default,
        Expression<Func<TEntity, object?>>[]? includes = default,
        CancellationToken cancellationToken = default)
    {
        includes ??= [];
        IQueryable<TEntity>? queryable = _dbContext.Set<TEntity>();

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

        return await queryable.ToListAsync(cancellationToken);
    }

    public virtual TEntity Add(TEntity entity)
    {
        return _dbContext
            .Add(entity)
            .Entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        return _dbContext
            .Set<TEntity>()
            .Update(entity)
            .Entity;
    }

    public void Remove(Guid id)
    {
        _dbContext
            .Set<TEntity>()
            .Remove(new TEntity { Id = id });
    }
}
