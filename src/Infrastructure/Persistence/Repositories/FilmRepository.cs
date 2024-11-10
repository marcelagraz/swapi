using Microsoft.EntityFrameworkCore;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Repositories;

public class FilmRepository(SwApiDbContext dbContext) : Repository<Film>(dbContext), IFilmRepository
{
    public async Task<Film?> FindAsync(Guid id, CancellationToken cancellationToken = default) =>
        await base.FindAsync(id, cancellationToken: cancellationToken);

    public async Task<List<Film>> FindAllAsync(
        int? pageNumber = default,
        int? pageSize = default,
        CancellationToken cancellationToken = default) =>
        await base.FindAllAsync(pageNumber, pageSize, cancellationToken: cancellationToken);

    public async Task AddAsync(Film film, CancellationToken cancellationToken = default)
    {
        base.Add(film);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Film film, CancellationToken cancellationToken = default)
    {
        base.Update(film);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Film film, CancellationToken cancellationToken = default)
    {
        base.Remove(film);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public new async Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default) =>
        await base.AnyAsync(id, cancellationToken);
}
