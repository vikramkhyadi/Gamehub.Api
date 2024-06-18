﻿namespace Gamehub.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
         private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
         RequestDelegate next,
         ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //handle exception
                var traceId = Guid.NewGuid();
                _logger.LogError($"{traceId}");
            }
        }
    }
}
