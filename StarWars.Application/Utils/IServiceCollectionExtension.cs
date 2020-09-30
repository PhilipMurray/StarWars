using Microsoft.Extensions.DependencyInjection;
using StarWars.Application.Interfaces;
using StarWars.Application.Services;
using System.Diagnostics.CodeAnalysis;

namespace StarWars.Application.Utils
{
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStarWarsApplicationService, StarWarsApplicationService>();

            return services;
        }
    }
}
