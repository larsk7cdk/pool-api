using bbob_bff.Middlewares;
using Microsoft.AspNetCore.Builder;

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