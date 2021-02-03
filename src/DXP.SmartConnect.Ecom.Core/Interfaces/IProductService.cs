using DXP.SmartConnect.Ecom.Core.DTOs;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByUpcAsync(string storeId, string upc);
        Task<ProductDto> GetProductByUpcDbAsync(string storeId, string upc);

    }
}
