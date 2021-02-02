using DXP.SmartConnect.Ecom.Core.DTOs;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ​api​/Product​/GetProductByUpc
        [HttpGet("GetProductByUpc")]
        public async Task<ProductDto> GetProductByUpc(string storeId, string upc)
        {
            var product = await _productService.GetProductByUpcAsync(storeId, upc);
            return product;
        }
    }
}
