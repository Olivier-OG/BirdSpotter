using System.Diagnostics;

namespace Server.Middleware;

public class LogginMiddleware
{
    private readonly ILogger<LogginMiddleware> logger;
    private readonly RequestDelegate next;

    public LogginMiddleware(ILogger<LogginMiddleware> logger, RequestDelegate next)
    {
        this.logger = logger;
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var watch = new Stopwatch();
        watch.Start();
        httpContext.Response.OnStarting(() =>
        {
            watch.Stop();
            logger.LogInformation(
                "Request for {Path} took: {Time}ms",
                httpContext.Request.Path.ToString(),
                watch.ElapsedMilliseconds.ToString()
            );
            return Task.CompletedTask;
        });
        await next(httpContext);
        watch.Stop();
    }
}