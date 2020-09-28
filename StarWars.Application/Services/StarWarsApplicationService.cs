using StarWars.Application.Interfaces;
using StarWars.Application.Models;
using StarWars.Domain;
using StarWars.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.Services
{
    public class StarWarsApplicationService : IStarWarsApplicationService
    {
        private readonly IStarshipRepository _starshipRepository;
        private readonly IStarshipResupplyCalculation _starshipResupplyCalculation;

        public StarWarsApplicationService(IStarshipRepository starshipRepository, IStarshipResupplyCalculation starshipResupplyCalculation)
        {
            _starshipRepository = starshipRepository;
            _starshipResupplyCalculation = starshipResupplyCalculation;
        }

        public GetStarshipsEnduranceResponse GetStarshipsEndurance(GetStarshipEnduranceRequest request)
        {
            var starshipEntities = _starshipRepository.GetStarshipEntities();

            var response = new GetStarshipsEnduranceResponse(new List<KeyValuePair<string, string>>());

            foreach (var starship in starshipEntities)
            {
                var starshipEnduranceDetails = _starshipResupplyCalculation.CalculateNumberOfResupplyStopsNeeded(starship, request.GetMegalightsToTravel());

                response.GetStarshipsEnduranceDetails().Add(starshipEnduranceDetails);
            }

            return response;
        }
    }
}
