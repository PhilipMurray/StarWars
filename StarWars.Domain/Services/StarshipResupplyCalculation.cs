using StarWars.Domain.Interfaces;
using StarWars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Services
{
    public class StarshipResupplyCalculation : IStarshipResupplyCalculation
    {
        private readonly ICalculationService _calculationService;

        public StarshipResupplyCalculation(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public KeyValuePair<string, string> CalculateNumberOfResupplyStopsNeeded(StarshipEntity starship, int distance)
        {
            var totalHoursOfConsumables = _calculationService.GetConsumablesInHours(starship.GetConsumables());
            var totalHoursOfTravel = _calculationService.GetTotalHoursToTravel(distance, starship.GetMGLT());

            if (totalHoursOfConsumables == null || totalHoursOfTravel == null)
            {
                return new KeyValuePair<string, string>(starship.GetName(), "unknown");
            }
            else
            {
                var numberOfStopsRequired = totalHoursOfTravel.Value / totalHoursOfConsumables.Value;

                return new KeyValuePair<string, string>(starship.GetName(), numberOfStopsRequired.ToString());
            }
        }
    }
}
