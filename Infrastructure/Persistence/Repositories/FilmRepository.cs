using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Repositories;

public class FilmRepository(DbContext dbContext) : Repository<Film>(dbContext)
{
    public async Task<Film?> FindAsync(Guid id, CancellationToken cancellationToken = default) =>
        await base.FindAsync(id, cancellationToken: cancellationToken);

    public async Task<List<Film>> FindAllAsync(CancellationToken cancellationToken = default) =>
        await base.FindAllAsync(cancellationToken: cancellationToken);

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
        Guard.Against.Null(film.Id);

        base.Remove(film.Id.Value);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
