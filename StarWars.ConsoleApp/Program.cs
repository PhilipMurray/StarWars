using Microsoft.Extensions.DependencyInjection;
using StarWars.Application.Interfaces;
using StarWars.Application.Models;
using StarWars.Application.Utils;
using StarWars.Domain.Utils;
using StarWars.Infrastructure.Utils;
using System;

namespace StarWars.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.PrintTitle();

            IServiceCollection services = new ServiceCollection();
            services.AddInfrastructureServices();
            services.AddInfrastructureAutoMapper();
            services.AddDomainServices();
            services.AddApplicationServices();

            var provider = services.BuildServiceProvider();
            using (var scope = provider.CreateScope())
            {
                var starWarsApplicationService = scope.ServiceProvider.GetService<IStarWarsApplicationService>();

                var megalights = Helper.ReadMegalightInput();

                var response = starWarsApplicationService.GetStarshipsEndurance(new GetStarshipEnduranceRequest(megalights));

                Helper.WriteTableHeader("Starships","Number of Resupply Stops");

                response.GetStarshipsEnduranceDetails().ForEach(x => { Helper.WriteTableRow(x.Key, x.Value); });

                Console.ReadKey();
            }

        }
    }
}
