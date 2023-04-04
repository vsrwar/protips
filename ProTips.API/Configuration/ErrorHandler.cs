using System.Net;
using System.Text.Json;
using ProTips.Entity.Utils;

namespace ProTips.API.Configuration;

public class ErrorHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger _log;

    public ErrorHandler(RequestDelegate next, ILoggerFactory log){
        _next = next;
        _log = log.CreateLogger("MyErrorHandler");
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(Exception ex)
        {
            await HandleErrorAsync(httpContext, ex);
        }
    }

    private async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var errorResponse = new ErrorResponse
        {
            StatusCode = HttpStatusCode.InternalServerError,
            Message = exception.Message,
            Exception = exception.InnerException
        };

        _log.LogError($"Error: {exception.Message}");
        _log.LogError($"Stack: {exception.StackTrace}");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) errorResponse.StatusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}
