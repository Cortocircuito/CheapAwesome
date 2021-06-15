using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.Utils.Refit
{
    public class RefitClientFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public RefitClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>() where T : IRefitClient
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
