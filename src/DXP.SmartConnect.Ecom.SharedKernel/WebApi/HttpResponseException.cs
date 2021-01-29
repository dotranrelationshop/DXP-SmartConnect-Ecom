using System;
using System.Net;
using System.Net.Http;

namespace DXP.SmartConnect.Ecom.SharedKernel.WebApi
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }


        public HttpResponseException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
            Content = message;
        }

        public HttpResponseException(HttpStatusCode statusCode, string message, Exception exception) : base(message, exception)
        {
            StatusCode = statusCode;
        }
    }
}
