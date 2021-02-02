using DXP.SmartConnect.Ecom.SharedKernel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace DXP.SmartConnect.Ecom.SharedKernel.Extensions
{
    public static class HttpClientPolicyExtensions
    {
        public static IHttpClientBuilder AddFaultHandlePolicies(this IHttpClientBuilder builder)
        {
            return builder
                .AddPolicyHandler((serviceProvider, request) =>
                {
                    var factory = serviceProvider.GetService<IWebApiPolicyFactory>();
                    // Retries should only be performed on idempotent operations
                    return request.Method == HttpMethod.Get ? factory.CreateWaitAndRetryPolicy() : factory.NoPolicy();
                })
                .AddPolicyHandler((serviceProvider, request) => serviceProvider.GetService<IWebApiPolicyFactory>().CreateTimeoutPolicy()) // Place the timeoutPolicy inside the retryPolicy, to make it time out each try.
                .AddPolicyHandler((serviceProvider, request) => serviceProvider.GetService<IWebApiPolicyFactory>().CreateCircuitBreakerPolicy(request));
        }
    }
}
