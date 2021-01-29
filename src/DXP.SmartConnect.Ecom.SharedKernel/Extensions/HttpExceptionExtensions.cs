using Microsoft.AspNetCore.Builder;
using DXP.SmartConnect.Ecom.SharedKernel.WebApi;

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
