using Newtonsoft.Json;
using DXP.SmartConnect.Ecom.API;
using DXP.SmartConnect.Ecom.Core.DTOs;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DXP.SmartConnect.Ecom.FunctionalTests.Api
{
    public class ProductControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProductControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetProductByUpcTest_ReturnsProduct()
        {
            // arrange 
            var storeId = "502";
            var upc = "00055991071034";

            // act
            var response = await _client.GetAsync($"/api/Product/GetProductByUpc?storeId={storeId}&upc={upc}");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDTO>(stringResponse);

            // assert
            Assert.NotNull(product);
        }

        [Fact]
        public async Task GetProductByUpcTest_ReturnsProductNotFound()
        {
            // arrange 
            var storeId = "5022";
            var upc = "00055991071032";

            // act
            var response = await _client.GetAsync($"/api/Product/GetProductByUpc?storeId={storeId}&upc={upc}");
            var stringResponse = await response.Content.ReadAsStringAsync();

            // assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Contains("ApiException", stringResponse);
        }
    }
}
