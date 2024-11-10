using Ardalis.GuardClauses;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Respawn;
using SwApi.Infrastructure.Persistence;
using System.Data.Common;

namespace SwApi.Api.IntegrationTests;

public class SqlServerTestDb
{
    private readonly string _connectionString = null!;
    private SqlConnection _connection = null!;
    private Respawner _respawner = null!;

    public SqlServerTestDb(IConfigurationRoot configuration)
    {
        var connectionString = configuration.GetConnectionString("TestConnection");

        Guard.Against.Null(connectionString);

        _connectionString = connectionString;
    }

    public async Task InitialiseAsync()
    {
        _connection = new SqlConnection(_connectionString);

        DbContextOptions<SwApiDbContext> options = new DbContextOptionsBuilder<SwApiDbContext>()
            .UseSqlServer(_connectionString)
            .Options;

        var context = new SwApiDbContext(options);

        context.Database.Migrate();

        _respawner = await Respawner.CreateAsync(_connectionString, new RespawnerOptions
        {
            TablesToIgnore = ["__EFMigrationsHistory"],
            CheckTemporalTables = true
        });
    }

    public DbConnection GetConnection()
    {
        return _connection;
    }

    public string GetConnectionString()
    {
        return _connectionString;
    }

    public async Task ResetAsync()
    {
        await _respawner.ResetAsync(_connectionString);
    }

    public async Task DisposeAsync()
    {
        await _connection.DisposeAsync();
    }
}
