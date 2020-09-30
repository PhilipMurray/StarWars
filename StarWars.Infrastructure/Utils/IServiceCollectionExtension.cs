using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using StarWars.Domain.Interfaces;
using StarWars.Infrastructure.Interfaces;
using StarWars.Infrastructure.Repositories;
using StarWars.Infrastructure.Services;
using StarWars.Infrastructure.Utils.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Infrastructure.Utils
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IApiContext, ApiContext>();
            services.AddScoped<IStarshipRepository, StarshipRepository>();
            services.AddScoped<IRestClient, RestClient>();
            return services;
        }

        public static IServiceCollection AddInfrastructureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InfrastructureProfile));
            return services;
        }
    }
}
