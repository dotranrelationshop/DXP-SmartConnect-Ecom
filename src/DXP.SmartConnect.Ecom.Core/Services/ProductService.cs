using DXP.SmartConnect.Ecom.Core.DTOs;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductWebApiClient _productWebApiClient;

        public ProductService(IProductWebApiClient productWebApiClient)
        {
            _productWebApiClient = productWebApiClient;
        }

        public async Task<ProductDTO> GetProductByUpcAsync(string storeId, string upc)
        {
            var product = await _productWebApiClient.GetProductByUpcAsync(storeId, upc);

            return ProductDTO.FromProduct(product);
        }
    }
}
