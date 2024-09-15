using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Middleware.Middleware
{
    public class RequestTimeTrackingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestTimeTrackingMiddleware(RequestDelegate next, ILogger<RequestTimeTrackingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestId = context.TraceIdentifier;
            var requestPath = context.Request.Path.Value;
            var stopwatch = Stopwatch.StartNew();

            _logger.LogInformation("Request to {0} with {1}:ID starts", requestPath, requestId);

            await _next(context);

            stopwatch.Stop();
            _logger.LogInformation("Request to {0} with {1}:ID ends in {2}", requestPath, requestId, stopwatch.Elapsed);
        }
    }
}
