using AutoMapper;
using StarWars.Domain.Models;
using StarWars.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Infrastructure.Utils.AutoMapper
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<StarshipDTO, StarshipEntity>();
        }
    }
}
