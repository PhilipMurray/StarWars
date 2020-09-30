using Microsoft.Extensions.DependencyInjection;
using StarWars.Application.Interfaces;
using StarWars.Application.Services;

namespace StarWars.Application.Utils
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStarWarsApplicationService, StarWarsApplicationService>();

            return services;
        }
    }
}
