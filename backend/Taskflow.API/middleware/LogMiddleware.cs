namespace Taskflow.middleware;

public class LogMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<LogMiddleware> logger;

    public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var start = DateTime.UtcNow;
        var ip = context.Connection.RemoteIpAddress?.ToString();
        var userId = context.User?.FindFirst("sub")?.Value;

        logger.LogInformation(
            "Request {Method} {Path} from IP {IP} User {UserId}",
            context.Request.Method,
            context.Request.Path,
            ip,
            userId);

        await next(context);

        var duration = DateTime.UtcNow - start;

        logger.LogInformation(
            "{Method} {Path} responded {StatusCode} in {Duration}ms",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            duration.TotalMilliseconds);
    }
}