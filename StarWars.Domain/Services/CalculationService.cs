using StarWars.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Services
{
    public class CalculationService : ICalculationService
    {
        public int? GetConsumablesInHours(string consumables)
        {
            if (string.IsNullOrEmpty(consumables))
                return null;

            var split = consumables.Split();

            switch (split[1].ToLower())
            {
                case "years":
                    return (24 * 365) * Convert.ToInt32(split[0]);
                case "year":
                    return (24 * 365) * Convert.ToInt32(split[0]);
                case "months":
                    return (24 * 30) * Convert.ToInt32(split[0]);
                case "month":
                    return (24 * 30) * Convert.ToInt32(split[0]);
                case "weeks":
                    return (24 * 7) * Convert.ToInt32(split[0]);
                case "week":
                    return (24 * 7) * Convert.ToInt32(split[0]);
                case "days":
                    return (24 * 1) * Convert.ToInt32(split[0]);
                case "day":
                    return (24 * 1) * Convert.ToInt32(split[0]);
                default:
                    return 0;
            }
        }

        public int? GetTotalHoursToTravel(int distance, int? distancePerHour)
        {
            if (distancePerHour == null)
                return null;

            return distance / distancePerHour.Value;
        }
    }
}
