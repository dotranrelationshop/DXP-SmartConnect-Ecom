using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Polly;
using Polly.CircuitBreaker;
using Polly.Timeout;
using DXP.SmartConnect.Ecom.SharedKernel.Extensions;
using DXP.SmartConnect.Ecom.SharedKernel.Interfaces;
using DXP.SmartConnect.Ecom.SharedKernel.WebApi;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using Xunit;

namespace DXP.SmartConnect.Ecom.Test.SharedKernel
{
    public class WebApiPolicyTest
    {
        private readonly IWebApiPolicyFactory _mockPolicyFactory;
        private readonly HttpClient _httpClient;

        public WebApiPolicyTest()
        {
            // Setup logger
            var mockPolicyLogger = new Mock<ILogger<WebApiPolicyFactory>>();

            // Setup httpclient
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://httpstat.us/")
            };

            // Setup Policy
            WebApiFaultHandleConfiguration config = new WebApiFaultHandleConfiguration
            {
                MaxRetryAttempts = 3,
                InitialRetryDelayInSec = 1,
                DurationOnBreakInSec = 10,
                ExceptionsAllowedBeforeBreaking = 1,
                WebApiTimeoutInMs = 3000
            };
            IOptions<WebApiFaultHandleConfiguration> option = Options.Create(config);

            _mockPolicyFactory = new WebApiPolicyFactory(mockPolicyLogger.Object, option);
        }

        [Fact]
        public void PolicyTimeout_ThrowTimeoutException()
        {
            var policy = _mockPolicyFactory.CreateTimeoutPolicy();

            var path = "200?sleep=10000"; // delay on response for 5 sec;

            // act
            var watch = new Stopwatch();
            watch.Start();

            var exc = Record.ExceptionAsync(() => policy.ExecuteAsync((ct) => _httpClient.GetAsync(path, ct), CancellationToken.None)).GetAwaiter().GetResult();


            watch.Stop();
            var time = watch.ElapsedMilliseconds;

            // assert
            Assert.IsType<TimeoutRejectedException>(exc);
        }

        [Fact]
        public void PolicyWaitAndRetry_Return500()
        {
            var policy = _mockPolicyFactory.CreateWaitAndRetryPolicy();

            var path = "500";

            // act
            var exc = Record.ExceptionAsync(() => policy.ExecuteAsync((ct) => _httpClient.GetAsync(path, ct), CancellationToken.None)).GetAwaiter().GetResult();

            // assert
            Assert.Null(exc);
        }

        [Fact]
        public void PolicyCircuitBreaker_ThrowBrokenCircuitException()
        {
            var path = "500";

            var request = new HttpRequestMessage(HttpMethod.Get, path);
            request.SetBearerToken("test-token");

            var policy = _mockPolicyFactory.CreateCircuitBreakerPolicy(request);

            // act
            Exception exc = Record.ExceptionAsync(() => policy.ExecuteAsync((ct) => _httpClient.SendAsync(request, ct), CancellationToken.None)).GetAwaiter().GetResult();

            // assert
            Assert.IsType<BrokenCircuitException>(exc);
        }

        [Fact]
        public void PolicyWrap_ThrowException()
        {
            // Given / Arrange 
            var mockPolicyLogger = new Mock<ILogger<WebApiPolicyFactory>>();

            // Setup Policy
            WebApiFaultHandleConfiguration config = new WebApiFaultHandleConfiguration
            {
                MaxRetryAttempts = 3,
                InitialRetryDelayInSec = 1,
                DurationOnBreakInSec = 10,
                ExceptionsAllowedBeforeBreaking = 3,
                WebApiTimeoutInMs = 3000
            };
            IOptions<WebApiFaultHandleConfiguration> option = Options.Create(config);

            var mockPolicyFactory = new WebApiPolicyFactory(mockPolicyLogger.Object, option);

            var path = "500";

            var request = new HttpRequestMessage(HttpMethod.Get, path);
            request.SetBearerToken("test-token");

            var cbPolicy = mockPolicyFactory.CreateCircuitBreakerPolicy(request);
            var warPolicy = mockPolicyFactory.CreateWaitAndRetryPolicy();
            var tPolicy = mockPolicyFactory.CreateTimeoutPolicy();

            var policyWrap = Policy.WrapAsync(warPolicy, tPolicy, cbPolicy);

            // config httpClient
            var clientName = "TestPolicyWrap";
            IServiceCollection services = new ServiceCollection();
            services
                .AddSingleton<IWebApiPolicyFactory, WebApiPolicyFactory>()
                .AddHttpClient(clientName)
                .AddPolicyHandler(policyWrap);
            HttpClient configuredClient = services
                .BuildServiceProvider()
                .GetRequiredService<IHttpClientFactory>()
                .CreateClient(clientName);
            configuredClient.BaseAddress = new Uri("https://httpstat.us/");

            // act
            Exception exc = Record.ExceptionAsync(() => configuredClient.SendAsync(request)).GetAwaiter().GetResult();

            // assert
            Assert.IsType<BrokenCircuitException>(exc);
        }
    }
}
