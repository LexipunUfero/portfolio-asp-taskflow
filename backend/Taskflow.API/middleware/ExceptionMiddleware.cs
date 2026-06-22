using System.Net;
using System.Text.Json;

namespace Taskflow.middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionMiddleware> logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var path = context.Request.Path;
            var method = context.Request.Method;

            logger.LogError(ex,
                "Error on {Method} {Path}",
                method,
                path);

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            error = "Internal Server Error",
            message = exception.Message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}