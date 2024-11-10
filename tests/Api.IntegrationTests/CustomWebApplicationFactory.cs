using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SwApi.Infrastructure.Persistence;
using System.Data.Common;

namespace SwApi.Api.IntegrationTests;

public class CustomWebApplicationFactory(DbConnection connection) : WebApplicationFactory<Program>
{
    private readonly DbConnection _connection = connection;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContextOptions<SwApiDbContext>>();
            services.AddDbContext<SwApiDbContext>(options => options.UseSqlServer(_connection));
        });
    }
}
