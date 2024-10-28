using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SharedLibrary.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            var statusCode = GetStatusCodeFromException(exception);

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = exception.GetType().Name,
                Detail = exception.Message,
                Instance = httpContext.Request.Path,
                Type = exception.GetType().Name,
            };

            httpContext.Response.StatusCode = statusCode;
            
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        private static int GetStatusCodeFromException(Exception exception)
        {
            // Handle proper status code based on actual exception
            return StatusCodes.Status500InternalServerError;
        }
    }
}
