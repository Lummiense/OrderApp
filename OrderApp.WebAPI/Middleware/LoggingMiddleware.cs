using System.Diagnostics;

namespace OrderApp.WebAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        private const string MessageTemplate = "HTTP {RequestMethod} {RequestPath} {Query} {QueryString} Response {StatusCode} in {Elapsed}";

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, ILogger<LoggingMiddleware> logger)
        {
            var timer = new Stopwatch();
            timer.Start();
            await _next(httpContext);
            timer.Stop();
            var elapsedMs = timer.Elapsed;


            logger.Log(LogLevel.Information, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path,
                httpContext.Request.Query, httpContext.Request.QueryString, httpContext.Response?.StatusCode,
                elapsedMs);
        }

    }
    public static class LoggingMiddlewareAppExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }

    }

}

