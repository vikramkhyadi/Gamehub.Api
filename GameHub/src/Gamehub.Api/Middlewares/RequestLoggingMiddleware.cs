
namespace Gamehub.Api.Middlewares
{
    /// <summary>
    /// Middleware which logs request made to application
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task Invoke(HttpContext httpContext)
        {

            // Handle logging, adding header 
            var request = httpContext.Request;
            _logger.LogInformation($"Requested path is : {request.Path}");
            await _next(httpContext);
        }

    }
}
