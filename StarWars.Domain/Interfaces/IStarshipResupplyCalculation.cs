using StarWars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Interfaces
{
    public interface IStarshipResupplyCalculation
    {
        public KeyValuePair<string, string> CalculateNumberOfResupplyStopsNeeded(StarshipEntity starship, int distance);
    }
}
