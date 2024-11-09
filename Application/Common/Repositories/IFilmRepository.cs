using SwApi.Domain.Entities;

namespace SwApi.Application.Common.Repositories;

public interface IFilmRepository
{
    Task<Film?> FindAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<Film>> FindAllAsync(
        int? pageNumber = default,
        int? pageSize = default,
        CancellationToken cancellationToken = default);

    Task AddAsync(Film film, CancellationToken cancellationToken = default);

    Task UpdateAsync(Film film, CancellationToken cancellationToken = default);

    Task DeleteAsync(Film film, CancellationToken cancellationToken = default);
}
