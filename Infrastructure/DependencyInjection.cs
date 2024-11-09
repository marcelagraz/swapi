using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwApi.Application.Common.Repositories;
using SwApi.Infrastructure.Persistence;
using SwApi.Infrastructure.Persistence.Repositories;

namespace SwApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddDbContext<SwApiDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddSingleton(TimeProvider.System);

        services.AddScoped<IFilmRepository, FilmRepository>();
        services.AddScoped<IPeopleRepository, PeopleRepository>();
        services.AddScoped<IPlanetRepository, PlanetRepository>();

        return services;
    }
}
