using System;
using System.Net;
using System.Runtime.Serialization;

namespace DXP.SmartConnect.Ecom.SharedKernel.WebApi
{
    [Serializable]
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }

        public HttpResponseException() : base()
        {
        }

        public HttpResponseException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
            Content = message;
        }

        public HttpResponseException(HttpStatusCode statusCode, string message, Exception exception) : base(message, exception)
        {
            StatusCode = statusCode;
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
