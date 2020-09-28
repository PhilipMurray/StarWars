using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Interfaces
{
    public interface ICalculationService
    {
        public int? GetTotalHoursToTravel(int distance, int? distancePerHour);

        public int? GetConsumablesInHours(string consumables);

    }
}
