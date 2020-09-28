using Microsoft.Extensions.DependencyInjection;
using StarWars.Domain.Interfaces;
using StarWars.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Utils
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICalculationService, CalculationService>();
            services.AddScoped<IStarshipResupplyCalculation, StarshipResupplyCalculation>();

            return services;
        }
    }
}
