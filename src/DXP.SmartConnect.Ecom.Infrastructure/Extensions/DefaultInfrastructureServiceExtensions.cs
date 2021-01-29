using Microsoft.Extensions.DependencyInjection;
using DXP.SmartConnect.Ecom.SharedKernel.WebApi;
using Microsoft.Extensions.Configuration;
using DXP.SmartConnect.Ecom.SharedKernel.Interfaces;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using DXP.SmartConnect.Ecom.Infrastructure.Data.WebApiClients;
using DXP.SmartConnect.Ecom.SharedKernel.Extensions;
using System;
using DXP.SmartConnect.Ecom.Core.Settings;

namespace DXP.SmartConnect.Ecom.Infrastructure.Extensions
{
    public static class DefaultInfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServiceConfig(this IServiceCollection services, IConfiguration config)
        {
            string providerRequestUri = config.GetSection("ProviderSettings")?["RequestUri"];

            services
                .Configure<WebApiFaultHandleConfiguration>(c =>
            {
                var settings = config.GetSection("FaultHanderSettings");
                c.DurationOnBreakInSec = int.Parse(settings["DurationOnBreakInSec"]);
                c.WebApiTimeoutInMs = int.Parse(settings["WebApiTimeoutInMs"]);
                c.ExceptionsAllowedBeforeBreaking = int.Parse(settings["ExceptionsAllowedBeforeBreaking"]);
                c.InitialRetryDelayInSec = int.Parse(settings["InitialRetryDelayInSec"]);
                c.MaxRetryAttempts = int.Parse(settings["MaxRetryAttempts"]);
            });
            services
                .AddSingleton<IWebApiPolicyFactory, WebApiPolicyFactory>();
            services
                .AddHttpClient<IProductWebApiClient, ProductWebApiClient>(client =>
                    client.BaseAddress = new Uri(providerRequestUri))
                .AddFaultHandlePolicies();

            return services;
        }
    }
}
