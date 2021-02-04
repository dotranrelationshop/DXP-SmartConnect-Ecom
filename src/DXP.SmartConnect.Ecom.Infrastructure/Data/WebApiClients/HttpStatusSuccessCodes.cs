using DXP.SmartConnect.Ecom.SharedKernel;
using System.Net;

namespace DXP.SmartConnect.Ecom.Infrastructure.Data.WebApiClients
{
    public class HttpStatusSuccessCodes : ValueObject
    {
        /// <summary>
        /// List HttpStatus Codes get shopping cart accepted.
        /// </summary>
        public static HttpStatusCode[] GetCart { get; } = {
           HttpStatusCode.OK, // 200
           HttpStatusCode.NoContent, // 204
           HttpStatusCode.NotFound, // 404
           HttpStatusCode.NotModified // 304
        };

        /// <summary>
        /// List HttpStatus Codes accepted when shopping cart change.
        /// </summary>
        public static HttpStatusCode[] CartChange { get; } = {
           HttpStatusCode.Accepted // 202
        };
    }
}
