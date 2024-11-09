using Microsoft.EntityFrameworkCore;
using SwApi.Domain.Entities;
using System.Reflection;

namespace SwApi.Infrastructure.Persistence;

public class SwApiDbContext(DbContextOptions<SwApiDbContext> options) : DbContext(options)
{
    public DbSet<People> Peoples => Set<People>();

    public DbSet<Film> Films => Set<Film>();

    public DbSet<Planet> Planets => Set<Planet>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
