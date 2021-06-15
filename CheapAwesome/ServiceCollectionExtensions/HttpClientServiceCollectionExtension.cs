using CheapAwesome.Infrastructure.BargainCouplesClient;
using CheapAwesome.Utils.Refit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace CheapAwesome.ServiceCollectionExtensions
{
    public static class HttpClientServiceCollectionExtension
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<RefitClientFactory>();

            services.AddHttpClient(nameof(IBargainCouplesClient), c =>
            {
                c.BaseAddress = new Uri("https://webbedsdevtest.azurewebsites.net/");
            }).AddTypedClient(c => RestService.For<IBargainCouplesClient>(c));

            return services;
        }
    }
}
