using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Repositories;

public class PlanetRepository(DbContext dbContext) : Repository<Planet>(dbContext)
{
    public async Task<Planet?> FindAsync(Guid id, CancellationToken cancellationToken = default) =>
        await base.FindAsync(id, cancellationToken: cancellationToken);

    public async Task<List<Planet>> FindAllAsync(CancellationToken cancellationToken = default) =>
        await base.FindAllAsync(cancellationToken: cancellationToken);

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

    public async Task DeleteAsync(Planet planet, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(planet.Id);

        base.Remove(planet.Id.Value);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
