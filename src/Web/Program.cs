using Core.Constants;
using Core.ExceptionHandling;
using Data;
using Services;

namespace Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDataServices(builder.Configuration);
        builder.Services.AddApplicationServices();
        builder.Services.AddPresentationServices(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseRateLimiter();

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers().RequireRateLimiting(RateLimitPolicies.Fixed);

        app.Run();
    }
}
