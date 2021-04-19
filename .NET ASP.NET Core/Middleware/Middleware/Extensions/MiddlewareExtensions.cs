using Microsoft.AspNetCore.Builder;
using Middleware.Middleware;

namespace Middleware.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimeTracking(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimeTrackingMiddleware>();
        }
    }
}
