using DXP.SmartConnect.Ecom.SharedKernel.Extensions;
using DXP.SmartConnect.Ecom.SharedKernel.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DXP.SmartConnect.Ecom.UnitTests.Extensions
{
    public class HttpExceptionExtensionsTest
    {
        [Fact]
        public async Task HttpExceptionMiddlewareTest_ReturnsNotFoundForRequest()
        {
            // arrange 
            // Setup test server
            using var host = await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                        })
                        .Configure(app =>
                        {
                            app.UseHttpClientException();
                        });
                })
                .StartAsync();

            var server = host.GetTestServer();
            server.BaseAddress = new Uri("https://storefrontgateway.unt.stg.v8.commerce.mi9cloud.com/api/");

            // Setup logger
            var mockLogger = new Mock<ILogger<WebApiClient>>();

            // Data
            var path = $"stores/502/products/00055991071034";

            var webApiClient = new WebApiClient(mockLogger.Object, server.CreateClient());

            // acc
            var exc = (HttpResponseException)Record.Exception(() => webApiClient.GetAsync<object>(path).GetAwaiter().GetResult());

            // assert
            Assert.NotNull(exc);
            Assert.Equal(HttpStatusCode.NotFound, exc.StatusCode);
        }
    }
}
