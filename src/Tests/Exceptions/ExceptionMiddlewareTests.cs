using Core.ExceptionHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.Exceptions;

public class ExceptionMiddlewareTests
{
    private readonly Mock<RequestDelegate> _nextMock;
    private readonly Mock<ILogger<ExceptionMiddleware>> _loggerMock;

    public ExceptionMiddlewareTests()
    {
        _nextMock = new Mock<RequestDelegate>();
        _loggerMock = new Mock<ILogger<ExceptionMiddleware>>();
    }

    [Fact]
    public async Task InvokeAsync_WhenExceptionIsThrown_ReturnsInternalServerError()
    {
        // Arrange
        var exception = new Exception("Test exception");
        _nextMock.Setup(n => n(It.IsAny<HttpContext>())).ThrowsAsync(exception);
        var middleware = new ExceptionMiddleware(_nextMock.Object, _loggerMock.Object);

        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, context.Response.StatusCode);
        Assert.Equal("application/json", context.Response.ContentType);

        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
        Assert.Contains("Internal Server Error. Please try again later.", responseBody);
        Assert.Contains("Test exception", responseBody);
    }
}
