using DXP.SmartConnect.Ecom.SharedKernel.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace DXP.SmartConnect.Ecom.SharedKernel.Extensions
{
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
