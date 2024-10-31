using Core.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;

namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddRepository();
        services.AddDoggieSerice();

        return services;
    }

    private static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IRepository, Repository>();

        return services;
    }

    private static IServiceCollection AddDoggieSerice(this IServiceCollection services)
    {
        services.AddScoped<IDoggieService, DoggieService>();

        return services;
    }
}
