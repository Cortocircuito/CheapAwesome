using CheapAwesome.Infrastructure.BargainCouplesClient;
using CheapAwesome.Utils.Refit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.ServiceCollectionExtensions
{
    public static class HttpClientServiceCollectionExtension
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            // Factory to use transient in a singleton service
            // have a look to https://josefottosson.se/you-are-probably-still-using-httpclient-wrong-and-it-is-destabilizing-your-software/
            services.AddSingleton<RefitClientFactory>();

            ///Register httpclient for Terito
            services.AddHttpClient(nameof(IBargainCouplesClient), c =>
            {
                c.BaseAddress = new Uri("https://webbedsdevtest.azurewebsites.net/");
            }).AddTypedClient(c => RestService.For<IBargainCouplesClient>(c));

            return services;
        }
    }
}
