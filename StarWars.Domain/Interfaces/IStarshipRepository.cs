using StarWars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Interfaces
{
    public interface IStarshipRepository
    {
        public List<StarshipEntity> GetStarshipEntities();

        public StarshipEntity GetStarshipEntity(int Id);
    }
}
