using Newtonsoft.Json;
using DXP.SmartConnect.Ecom.API;
using DXP.SmartConnect.Ecom.Core.DTOs;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DXP.SmartConnect.Ecom.FunctionalTests.Api
{
    public class AppControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public AppControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task InfoTest_ReturnsInfo()
        {
            // act
            var response = await _client.GetAsync("/readme");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            // assert
            Assert.Contains("server", stringResponse);
        }
    }
}
