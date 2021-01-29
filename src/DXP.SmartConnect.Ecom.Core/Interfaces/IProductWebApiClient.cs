using DXP.SmartConnect.Ecom.Core.Entities;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Interfaces
{
    public interface IProductWebApiClient
    {
        Task<Product> GetProductByUpcAsync(string storeId, string upc);
    }
}
