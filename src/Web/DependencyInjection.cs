using Core.Constants;
using Core.Options;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Web;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddRateLimiter(configuration);

        return services;
    }

    public static IServiceCollection AddRateLimiter(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RateLimitingOptions>(configuration.GetSection(RateLimitingOptions.Section));

        var rateLimitingOptions = configuration.GetSection(RateLimitingOptions.Section).Get<RateLimitingOptions>() ??
            throw new InvalidOperationException($"{nameof(RateLimitingOptions)} configuration section is missing or null.");

        services.AddRateLimiter(options =>
        {
            options.AddPolicy(RateLimitPolicies.Fixed, context => RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: context.Connection.RemoteIpAddress,
                factory: partition => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = rateLimitingOptions.PermitLimit,
                    Window = TimeSpan.FromSeconds(rateLimitingOptions.WindowSeconds)
                }));

            options.OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.HttpContext.Response.WriteAsync("Too many requests. Please try later again... ", cancellationToken: token);
            };
        });

        return services;
    }
}
