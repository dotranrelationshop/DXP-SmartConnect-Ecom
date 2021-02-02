using DXP.SmartConnect.Ecom.SharedKernel.WebApi;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace DXP.SmartConnect.Ecom.Test
{
    public class WebApiTest
    {
        private readonly WebApiClient _webApiClient;

        public WebApiTest()
        {
            // Setup logger
            var mockLogger = new Mock<ILogger<WebApiClient>>();

            // Setup httpclient
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://httpstat.us/")
            };

            _webApiClient = new WebApiClient(mockLogger.Object, httpClient);
        }

        [Fact]
        public void HttpGet_ReturnOk()
        {
            var path = "200";
            // act
            var ex = Record.ExceptionAsync(() => _webApiClient.GetAsync<object>(path)).GetAwaiter().GetResult();
            // assert
            Assert.Null(ex);
        }

        [Fact]
        public void HttpGet_ReturnExeption()
        {
            var path = "404";
            // act1
            var ex = Record.ExceptionAsync(() => _webApiClient.GetAsync<object>(path)).GetAwaiter().GetResult();
            var result = Assert.ThrowsAsync<HttpResponseException>(() => _webApiClient.GetAsync<object>(path)).GetAwaiter().GetResult();
            // assert
            Assert.NotNull(ex);
            Assert.True(result.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public void HttpPost_ReturnOk()
        {
            var path = "200";
            // act
            var ex = Record.ExceptionAsync(() => _webApiClient.PostAsync<object>(path, HttpMethod.Post, null)).GetAwaiter().GetResult();
            // assert
            Assert.Null(ex);
        }

        [Fact]
        public void HttpPostWithBoolType_ReturnTrue()
        {
            var path = "200";
            // act
            var ex = _webApiClient.PostAsync<bool>(path, HttpMethod.Post, null).GetAwaiter().GetResult();
            // assert
            Assert.True(ex);
        }

        [Fact]
        public void HttpPostWithBoolType_ReturnFalse()
        {
            var path = "404";
            // act
            var ex = _webApiClient.PostAsync<bool>(path, HttpMethod.Post, null).GetAwaiter().GetResult();
            // assert
            Assert.False(ex);
        }
    }
}
