using SwApi.Domain.Entities;

namespace SwApi.Application.Common.Repositories;

public interface IPlanetRepository
{
    Task<Planet?> FindAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<Planet>> FindAllAsync(
        int? pageNumber = default,
        int? pageSize = default,
        CancellationToken cancellationToken = default);

    Task AddAsync(Planet planet, CancellationToken cancellationToken = default);

    Task UpdateAsync(Planet planet, CancellationToken cancellationToken = default);

    Task DeleteAsync(Planet planet, CancellationToken cancellationToken = default);
}
