using DXP.SmartConnect.Ecom.Core.Entities;
using DXP.SmartConnect.Ecom.Infrastructure.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Xunit;

namespace DXP.SmartConnect.Ecom.UnitTests.WebApiClients
{
    public class DbContextTest
    {
        private readonly TestContext _dbContext;

        public DbContextTest()
        {
            ILoggerFactory MyLoggerFactory =
                LoggerFactory.Create(
                     builder =>
                     {
                         builder.AddConsole();
                         builder.AddDebug();
                     }
                );
            var options = new DbContextOptions<TestContext>();
            _dbContext = new TestContext(options, MyLoggerFactory);
        }

        [Fact]
        public async Task GetProductAsyncTest_ReturnProduct()
        {
            // arrange 
            var upc = 38375;

            // act
            var result = await _dbContext.Set<RsProduct>().SingleOrDefaultAsync(e => e.Id.Equals(upc));

            // assert
            Assert.IsType<RsProduct>(result);
        }

        [Fact]
        public async Task ParallelUpdateProductAsyncTest_ReturnOK()
        {
            // arrange 
            var updateProduct = new RsProduct
            {
                Id = 79531,
                Name = "Test change"
            };

            var updateProduct2 = new RsProduct
            {
                Id = 79532,
                Name = "Test change 123"
            };

            // act
            _dbContext.Entry(updateProduct).State = EntityState.Modified;
            var result = await _dbContext.SaveChangesAsync();

            _dbContext.Entry(updateProduct2).State = EntityState.Modified;
            var result2 = await _dbContext.SaveChangesAsync();

            // assert
            Assert.True(result > 0);
            Assert.True(result2 > 0);
        }

        [Fact]
        public void ParallelUpdateProductAsyncTest_ReturnException()
        {
            // arrange 
            var updateProduct = new RsProduct
            {
                Id = 79531,
                Name = "Test change 4"
            };

            var updateProduct2 = new RsProduct
            {
                Id = 79532,
                Name = "Test change 5"
            };

            // act
            _dbContext.Entry(updateProduct).State = EntityState.Modified;
            _dbContext.SaveChangesAsync();

            _dbContext.Entry(updateProduct2).State = EntityState.Modified;
            var result2 = Record.ExceptionAsync(() => _dbContext.SaveChangesAsync());

            // assert
            Assert.NotNull(result2);
        }
    }
}
