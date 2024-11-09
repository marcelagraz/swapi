using SwApi.Domain.Common;

namespace SwApi.Application.Common.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<TEntity>> FindAllAsync(
        int? pageNumber = default,
        int? pageSize = default,
        CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default);
}
