using Polly;
using System.Net.Http;

namespace DXP.SmartConnect.Ecom.SharedKernel.Interfaces
{
    public interface IWebApiPolicyFactory
    {
        /// <summary>
        /// Create WaitAndRetry policy.
        /// </summary>
        /// <returns>The policy instance.</returns>
        IAsyncPolicy<HttpResponseMessage> CreateWaitAndRetryPolicy();
        /// <summary>
        /// Create CircuitBreaker policy.
        /// </summary>
        /// <returns>The policy instance.</returns>
        IAsyncPolicy<HttpResponseMessage> CreateCircuitBreakerPolicy(HttpRequestMessage request);
        /// <summary>
        /// Create Timeout policy.
        /// </summary>
        /// <returns>The policy instance.</returns>
        IAsyncPolicy<HttpResponseMessage> CreateTimeoutPolicy();
        /// <summary>
        /// Function excute no policy.
        /// </summary>
        /// <returns>The policy instance.</returns>
        IAsyncPolicy<HttpResponseMessage> NoPolicy();
    }
}
