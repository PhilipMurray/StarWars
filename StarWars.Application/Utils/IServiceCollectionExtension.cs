using Microsoft.Extensions.DependencyInjection;
using StarWars.Application.Interfaces;
using StarWars.Application.Services;

namespace StarWars.Domain.Utils
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
