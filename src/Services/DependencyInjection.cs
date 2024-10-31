using Core.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;

namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddRepository();

        return services;
    }

    private static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IRepository, Repository>();

        return services;
    }
}
