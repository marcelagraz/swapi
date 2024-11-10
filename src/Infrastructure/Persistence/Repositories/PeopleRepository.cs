using Microsoft.EntityFrameworkCore;
using SwApi.Application.Common.Repositories;
using SwApi.Domain.Entities;
using SwApi.Infrastructure.Persistence.Common;

namespace SwApi.Infrastructure.Persistence.Repositories;

public class PeopleRepository(SwApiDbContext dbContext) : Repository<People>(dbContext), IPeopleRepository
{
    public async Task<People?> FindAsync(Guid id, CancellationToken cancellationToken = default) =>
        await base.FindAsync(id, cancellationToken: cancellationToken);

    public async Task<List<People>> FindAllAsync(
        int? pageNumber = default,
        int? pageSize = default,
        CancellationToken cancellationToken = default) =>
        await base.FindAllAsync(pageNumber, pageSize, cancellationToken: cancellationToken);

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
        base.Remove(people);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public new async Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default) =>
        await base.AnyAsync(id, cancellationToken);
}
