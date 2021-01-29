using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.CircuitBreaker;
using Polly.Extensions.Http;
using Polly.Registry;
using Polly.Timeout;
using DXP.SmartConnect.Ecom.SharedKernel.Interfaces;
using DXP.SmartConnect.Ecom.SharedKernel.ValueObjects;
using System;
using System.Linq;
using System.Net.Http;

namespace DXP.SmartConnect.Ecom.SharedKernel.WebApi
{
    /// <summary>
    /// Factory for producing WebApiClient policies handler.
    /// </summary>
    public class WebApiPolicyFactory : IWebApiPolicyFactory
    {
        private readonly ILogger<WebApiPolicyFactory> _logger;
        private readonly WebApiFaultHandleConfiguration _config;
        private readonly IConcurrentPolicyRegistry<string> _concurrentPolicyRegistry = new PolicyRegistry();

        public WebApiPolicyFactory(ILogger<WebApiPolicyFactory> logger, IOptions<WebApiFaultHandleConfiguration> options)
        {
            _logger = logger;
            _config = options.Value;
        }

        public IAsyncPolicy<HttpResponseMessage> CreateWaitAndRetryPolicy()
        {
            // Retry policy is stateless so can share same instance
            var waitAndRetryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError() // HttpRequestException, 5XX and 408
                .OrResult(response => HttpStatusCodes.WorthRetrying.Contains(response.StatusCode))
                .Or<Exception>(e => !(e is BrokenCircuitException)) // No retry when exception is belong CircuitBreaker Policy!
                .Or<TimeoutRejectedException>() // thrown by Polly's TimeoutPolicy if the inner call times out
                .WaitAndRetryAsync(
                _config.MaxRetryAttempts,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(_config.InitialRetryDelayInSec, retryAttempt)),
                OnRetry);

            return waitAndRetryPolicy;
        }

        public IAsyncPolicy<HttpResponseMessage> CreateCircuitBreakerPolicy(HttpRequestMessage request)
        {
            string policyKey = $"{request.Method}-{request.RequestUri.OriginalString}-{request.Headers?.Authorization?.GetHashCode()}";

            var circuitBreakerPolicy = HttpPolicyExtensions
                .HandleTransientHttpError() // HttpRequestException, 5XX and 408
                .OrResult(response => HttpStatusCodes.WorthRetrying.Contains(response.StatusCode))
                .Or<Exception>()
                .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: _config.ExceptionsAllowedBeforeBreaking,
                durationOfBreak: TimeSpan.FromSeconds(_config.DurationOnBreakInSec),
                onBreak: OnBreak,
                onReset: OnReset,
                onHalfOpen: OnHalfOpen
               );

            // Separate circuit breaker policies are possible because each independent circuit must have its own policy
            var policyWithKey = _concurrentPolicyRegistry.GetOrAdd(policyKey, circuitBreakerPolicy);

            return policyWithKey;
        }

        public IAsyncPolicy<HttpResponseMessage> CreateTimeoutPolicy()
        {
            var timeoutInSec = TimeSpan.FromMilliseconds(_config.WebApiTimeoutInMs).Seconds;
            var timeoutPolicy = Policy
                .TimeoutAsync<HttpResponseMessage>(timeoutInSec);

            return timeoutPolicy;
        }

        public IAsyncPolicy<HttpResponseMessage> NoPolicy()
        {
            var noPolicy = Policy.NoOpAsync<HttpResponseMessage>();

            return noPolicy;
        }

        private void OnRetry(DelegateResult<HttpResponseMessage> response, TimeSpan timespan)
        {
            // Log here
            System.Diagnostics.Debug.WriteLine($"{nameof(OnRetry)} - Retry with timespan {timespan}. Time {DateTime.UtcNow} exception {response?.Exception?.Message ?? response?.Exception?.InnerException?.Message ?? response?.Result?.ReasonPhrase} and Http Code {response?.Result?.StatusCode}.");
        }

        private void OnBreak(DelegateResult<HttpResponseMessage> response, TimeSpan timespan)
        {
            // Log here
            System.Diagnostics.Debug.WriteLine($"{nameof(OnBreak)} - Circuit is open with timespan {timespan}. Time {DateTime.UtcNow} - Provider Service Reason - {response.Result?.ReasonPhrase}.");

            throw new BrokenCircuitException($"{nameof(OnBreak)} - Circuit is open, no calls were attempted. Time {DateTime.UtcNow}. " +
                $"- Provider Service Reason - {response.Result?.ReasonPhrase}", response.Exception);
        }

        private void OnReset()
        {
            // Log here
            System.Diagnostics.Debug.WriteLine($"{nameof(OnReset)} - Time {DateTime.UtcNow}.");
        }

        private void OnHalfOpen()
        {
            // Log here
            System.Diagnostics.Debug.WriteLine($"{nameof(OnHalfOpen)} - Time {DateTime.UtcNow}.");
        }
    }
}
