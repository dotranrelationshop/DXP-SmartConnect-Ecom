using DXP.SmartConnect.Ecom.Core.Entities;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<RsProduct> GetProductByUpcAsync(string storeId, int upc);
    }
}
