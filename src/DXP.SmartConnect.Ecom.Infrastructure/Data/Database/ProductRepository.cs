using DXP.SmartConnect.Ecom.Core.Entities;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Infrastructure.Data.Database
{
    public class ProductRepository : EfRepository<DBContext, RsProduct, int>, IProductRepository
    {
        public ProductRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public Task<RsProduct> GetProductByUpcAsync(string storeId, int upc)
        {
            return _dbContext.RsProduct.AsQueryable().FirstOrDefaultAsync(p => p.Id == upc);
        }
    }
}