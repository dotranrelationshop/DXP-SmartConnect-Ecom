using DXP.SmartConnect.Ecom.SharedKernel.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace DXP.SmartConnect.Ecom.SharedKernel.Extensions
{
    public static class HttpExceptionExtensions
    {
        public static IApplicationBuilder UseHttpClientException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpExceptionMiddleware>();
        }
    }
}
