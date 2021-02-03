using DXP.SmartConnect.Ecom.Core.DTOs;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductWebApiClient _productWebApiClient;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductWebApiClient productWebApiClient, IProductRepository productRepository)
        {
            _productWebApiClient = productWebApiClient;
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetProductByUpcAsync(string storeId, string upc)
        {
            var product = await _productWebApiClient.GetProductByUpcAsync(storeId, upc);

            return ProductDto.FromProduct(product);
        }

        public async Task<ProductDto> GetProductByUpcDbAsync(string storeId, string upc)
        {
            var product = await _productRepository.GetProductByUpcAsync(storeId, int.Parse(upc));

            return ProductDto.FromRsProduct(product);
        }
    }
}
