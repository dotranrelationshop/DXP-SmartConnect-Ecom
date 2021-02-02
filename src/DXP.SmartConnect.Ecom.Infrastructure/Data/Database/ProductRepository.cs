using DXP.SmartConnect.Ecom.Core.Entities;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Infrastructure.Data.Database
{
    public class ProductRepository : EfRepository<DBContext, RsProduct, int>, IProductRepository
    {
        public ProductRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public Task<RsProduct> GetProductByUpcAsync(string storeId, string upc)
        {
            return _dbContext.RsProduct.FirstOrDefaultAsync(p => p.Sku == upc);
        }
    }
}