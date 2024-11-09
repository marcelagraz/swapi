using SwApi.Domain.Entities;

namespace SwApi.Application.Common.Repositories;

public interface IPeopleRepository
{
    Task<People?> FindAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<People>> FindAllAsync(
        int? pageNumber = default,
        int? pageSize = default,
        CancellationToken cancellationToken = default);

    Task AddAsync(People people, CancellationToken cancellationToken = default);

    Task UpdateAsync(People people, CancellationToken cancellationToken = default);

    Task DeleteAsync(People people, CancellationToken cancellationToken = default);
}
