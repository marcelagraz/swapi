using Microsoft.AspNetCore.Mvc;
using SwApi.Api.ExceptionHandling;

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

        services.AddExceptionHandler<GlobalExceptionHandler>();

        AddCorsPolicies(services);

        return services;
    }

    public static void AddCorsPolicies(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("SwUICorsPolicy", corsPolicyBuilder =>
            {
                corsPolicyBuilder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });
    }
}
