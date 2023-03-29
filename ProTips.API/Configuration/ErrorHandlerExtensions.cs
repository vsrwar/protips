namespace ProTips.API.Configuration;

public static class ErrorHandlerExtensions
{
    public static IApplicationBuilder UseMyErrorHandler(this IApplicationBuilder appBuilder)
    {
        return appBuilder.UseMiddleware<ErrorHandler>();
    }
}