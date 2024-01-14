using Microsoft.Extensions.DependencyInjection;
using Services.Birds;
using Shared.Birds;

namespace Services;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all services to the DI container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBirdServices(this IServiceCollection services)
    {
        services.AddScoped<IBirdService, BirdService>();

        // Add more services here...

        return services;
    }
}

