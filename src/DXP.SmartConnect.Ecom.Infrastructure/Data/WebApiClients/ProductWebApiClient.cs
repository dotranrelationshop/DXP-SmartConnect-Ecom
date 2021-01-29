using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DXP.SmartConnect.Ecom.Core.Entities;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using DXP.SmartConnect.Ecom.SharedKernel.WebApi;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Infrastructure.Data.WebApiClients
{
    public class ProductWebApiClient : WebApiClient, IProductWebApiClient
    {
        private static HttpStatusCode[] _productHttpStatusCodesSuccessfully = {
           HttpStatusCode.OK, // 200
           HttpStatusCode.NoContent, // 204
           HttpStatusCode.NotFound // 404
        };

        private readonly ILogger<ProductWebApiClient> _logger;

        public ProductWebApiClient(ILogger<ProductWebApiClient> logger, HttpClient client) : base(logger, client)
        {
            _logger = logger;
        }

        public Task<Product> GetProductByUpcAsync(string storeId, string upc)
        {
            HttpStatusCode[] productHttpStatusCodesSuccessfully = {
                HttpStatusCode.OK, // 200
                HttpStatusCode.NoContent, // 204
            };
            var path = $"stores/{storeId}/products/{upc}";
            return GetAsync<Product>(path, null, null, productHttpStatusCodesSuccessfully);
        }
    }
}
