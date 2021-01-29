using System.Net;

namespace DXP.SmartConnect.Ecom.SharedKernel.ValueObjects
{
    class HttpStatusCodes : ValueObject
    {
        /// <summary>
        /// List HttpStatus Codes worth retrying.
        /// </summary>
        public static HttpStatusCode[] WorthRetrying { get; } = {
           HttpStatusCode.RequestTimeout, // 408
           HttpStatusCode.InternalServerError, // 500
           HttpStatusCode.BadGateway, // 502
           HttpStatusCode.ServiceUnavailable, // 503
           HttpStatusCode.GatewayTimeout // 504
        };

        /// <summary>
        /// List default HttpStatus Codes successfully.
        /// </summary>
        public static HttpStatusCode[] DefaultSuccessfully { get; } = {
           HttpStatusCode.OK, // 200
           HttpStatusCode.NoContent // 204
        };
    }
}
