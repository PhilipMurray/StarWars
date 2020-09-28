using Microsoft.Extensions.DependencyInjection;
using StarWarsServices;
using StarWarsServices.Utilities;
using System;
using System.Threading;


namespace StarWarsConsoleApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            var applicationService = scope.ServiceProvider.GetRequiredService<ApplicationService>();

            Console.WriteLine(applicationService.Run());

            Console.WriteLine(HelperGetTitle());

            Console.WriteLine("Enter the number of Megalights(MGLT) you want to travel today:");

            var megalights = Console.ReadLine();

            


            DisposeServices();

            Console.WriteLine($"You would like to travel {megalights} MGLT.");
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddApplicationServices();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

        private static int HelperConsumablesInHours(string consumables)
        {
            var split = consumables.Split();
            

            switch (split[1].ToLower())
            {
                case "years":
                    return (24 * 365) * Convert.ToInt32(split[0]);
                case "months":
                    return (24 * 30) * Convert.ToInt32(split[0]);
                case "weeks":
                    return (24 * 7) * Convert.ToInt32(split[0]);
                case "days":
                    return (24 * 1) * Convert.ToInt32(split[0]);
                default:
                    return 0;
            }
        }

        private static string HelperGetTitle()
        {
            var title = @"
     _______.___________.    ___      .______      
    /       |           |   /   \     |   _  \     
   |   (----`---|  |----`  /  ^  \    |  |_)  |    
    \   \       |  |      /  /_\  \   |      /     
.----)   |      |  |     /  _____  \  |  |\  \----.
|_______/       |__|    /__/     \__\ | _| `._____|
                                                   
____    __    ____  ___      .______          _______.
\   \  /  \  /   / /   \     |   _  \        /       |
 \   \/    \/   / /  ^  \    |  |_)  |      |   (----`
  \            / /  /_\  \   |      /        \   \    
   \    /\    / /  _____  \  |  |\  \----.----)   |   
    \__/  \__/ /__/     \__\ | _| `._____|_______/   ";


            return title;
        }
    }
}
