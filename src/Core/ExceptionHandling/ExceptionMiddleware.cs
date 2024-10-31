using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.ExceptionHandling;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private const string ApplicationJsonType = "application/json";

    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (JsonException ex)
        {
            logger.LogWarning("Something went wrong: {ex}", ex);
            await HandleJsonExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            logger.LogError("Something went wrong: {ex}", ex);
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleJsonExceptionAsync(HttpContext context, Exception exception)
    {
        var handleExceptionModel = new HandleExceptionModel
        {
            Code = HttpStatusCode.BadRequest,
            Message = "Invalid JSON format",
            Details = exception.Message
        };

        var responseContent = JsonSerializer.Serialize(handleExceptionModel);

        context.Response.ContentType = ApplicationJsonType;
        context.Response.StatusCode = (int)handleExceptionModel.Code;

        await context.Response.WriteAsync(responseContent);
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var handleExceptionModel = new HandleExceptionModel
        {
            Code = HttpStatusCode.InternalServerError,
            Message = "Internal Server Error. Please try again later.",
            Details = exception.Message
        };

        var responseContent = JsonSerializer.Serialize(handleExceptionModel);

        context.Response.ContentType = ApplicationJsonType;
        context.Response.StatusCode = (int)handleExceptionModel.Code;

        return context.Response.WriteAsync(responseContent);
    }
}