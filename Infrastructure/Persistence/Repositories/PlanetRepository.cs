using Microsoft.EntityFrameworkCore;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Repositories;

public class PlanetRepository(SwApiDbContext dbContext) : Repository<Planet>(dbContext), IPlanetRepository
{
    public async Task<Planet?> FindAsync(Guid id, CancellationToken cancellationToken = default) =>
        await base.FindAsync(id, cancellationToken: cancellationToken);

    public async Task<List<Planet>> FindAllAsync(
        int? pageNumber = default,
        int? pageSize = default,
        CancellationToken cancellationToken = default) =>
        await base.FindAllAsync(pageNumber, pageSize, cancellationToken: cancellationToken);

    public async Task AddAsync(Planet planet, CancellationToken cancellationToken = default)
    {
        base.Add(planet);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Planet planet, CancellationToken cancellationToken = default)
    {
        base.Update(planet);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        base.Remove(id);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public new async Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default) =>
        await base.AnyAsync(id, cancellationToken);
}
