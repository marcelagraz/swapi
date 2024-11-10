using Microsoft.AspNetCore.Mvc;

namespace SwApi.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddOpenApiDocument((configure, sp) =>
        {
            configure.Title = "The Star Wars API";
        });

        return services;
    }
}
