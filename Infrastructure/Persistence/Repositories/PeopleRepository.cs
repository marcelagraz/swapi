using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Repositories;

public class PeopleRepository(DbContext dbContext) : Repository<People>(dbContext)
{
    public async Task<People?> FindAsync(Guid id, CancellationToken cancellationToken = default) =>
        await base.FindAsync(id, cancellationToken: cancellationToken);

    public async Task<List<People>> FindAllAsync(CancellationToken cancellationToken = default) =>
        await base.FindAllAsync(cancellationToken: cancellationToken);

    public async Task AddAsync(People people, CancellationToken cancellationToken = default)
    {
        base.Add(people);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(People people, CancellationToken cancellationToken = default)
    {
        base.Update(people);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(People people, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(people.Id);

        base.Remove(people.Id.Value);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
