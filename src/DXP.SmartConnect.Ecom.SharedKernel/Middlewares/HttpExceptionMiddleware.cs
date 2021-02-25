using DXP.SmartConnect.Ecom.SharedKernel.WebApi;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.SharedKernel.Middlewares
{
    internal class HttpExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public HttpExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);
            }
            catch (HttpResponseException responseException)
            {
                context.Response.StatusCode = (int)responseException.StatusCode;

                byte[] data = Encoding.UTF8.GetBytes(responseException.Content);
                context.Response.ContentType = "application/json";
                await context.Response.Body.WriteAsync(data, 0, data.Length);
            }
            catch (Exception exc)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                byte[] data = Encoding.UTF8.GetBytes(exc.Message);
                context.Response.ContentType = "application/json";
                await context.Response.Body.WriteAsync(data, 0, data.Length);
            }
        }
    }
}
