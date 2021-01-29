using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DXP.SmartConnect.Ecom.API;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using DXP.SmartConnect.Ecom.Infrastructure.Data.WebApiClients;
using System;
using System.Linq;

namespace DXP.SmartConnect.Ecom.FunctionalTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = builder.Build();

            host.Start();
            return host;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseSolutionRelativeContentRoot("src/DXP.SmartConnect.Ecom.API")
                .ConfigureServices(services =>
                {
                    services.AddHttpClient<IProductWebApiClient, ProductWebApiClient>(client => 
                    client.BaseAddress = new Uri("https://storefrontgateway.unt.stg.v8.commerce.mi9cloud.com/api/"));
                });
        }
    }
}