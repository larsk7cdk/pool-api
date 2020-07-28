using Microsoft.AspNetCore.Builder;
using pool_api.Middlewares;

namespace pool_api.Extensions
{
    public static class RequestResponseLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}