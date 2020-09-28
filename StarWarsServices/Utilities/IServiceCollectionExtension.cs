using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsServices.Utilities
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IService, Service>();
            services.AddSingleton<ApplicationService>();
            return services;
        }
    }
}
