using AutoMapper;
using Newtonsoft.Json;
using StarWars.Domain.Interfaces;
using StarWars.Domain.Models;
using StarWars.Infrastructure.DTO;
using StarWars.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Infrastructure.Repositories
{
    public class StarshipRepository : IStarshipRepository
    {
        private readonly IApiContext _apiContext;
        private readonly IMapper _mapper;
        private const string apiResource = "starships/";

        public StarshipRepository(IApiContext apiContext, IMapper mapper)
        {
            _apiContext = apiContext;
            _mapper = mapper;
        }

        public List<StarshipEntity> GetStarshipEntities()
        {
            string nextResource = apiResource;

            List<StarshipDTO> starshipDtoCollection = new List<StarshipDTO>();

            while (!string.IsNullOrEmpty(nextResource))
            {
                var jsonResponse = _apiContext.Get(nextResource);

                var baseApiResponse = JsonConvert.DeserializeObject<BaseApiResponse<StarshipDTO>>(jsonResponse);

                starshipDtoCollection.AddRange(baseApiResponse.Results);
                nextResource = baseApiResponse.Next;
            }

            var starshipEntities =_mapper.Map<List<StarshipDTO>, List<StarshipEntity>>(starshipDtoCollection);

            return starshipEntities;
        }

        public StarshipEntity GetStarshipEntity(int id)
        {
            StringBuilder stringBuilder = new StringBuilder(apiResource);
            stringBuilder.AppendFormat("{0}/", id);

            var jsonResponse = _apiContext.Get(stringBuilder.ToString());

            var starshipDTO = JsonConvert.DeserializeObject<StarshipDTO>(jsonResponse);

            var starshipEntity = _mapper.Map<StarshipEntity>(starshipDTO);

            return starshipEntity;
        }
    }
}
