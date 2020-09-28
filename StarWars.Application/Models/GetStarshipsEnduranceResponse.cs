using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.Models
{
    public class GetStarshipsEnduranceResponse
    {
        private List<KeyValuePair<string, string>> _starshipsEnduranceDetails;

        public GetStarshipsEnduranceResponse(List<KeyValuePair<string, string>> starshipsEnduranceDetails)
        {
            _starshipsEnduranceDetails = starshipsEnduranceDetails;
        }

        public List<KeyValuePair<string, string>> GetStarshipsEnduranceDetails()
        {
            return _starshipsEnduranceDetails;
        }
    }
}
