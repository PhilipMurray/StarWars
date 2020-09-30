using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.Models
{
    public class GetStarshipEnduranceRequest
    {
        private int _megalightsToTravel;

        public GetStarshipEnduranceRequest()
        {
        }

        public GetStarshipEnduranceRequest(int megalightsToTravel)
        {
            if (megalightsToTravel <= 0)
                throw new ArgumentException($"{nameof(megalightsToTravel)} must be greater than 0.");

            _megalightsToTravel = megalightsToTravel;
        }

        public int GetMegalightsToTravel()
        {
            return _megalightsToTravel;
        }
    }
}
