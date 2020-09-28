using StarWars.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.Interfaces
{
    public interface IStarWarsApplicationService
    {

        public GetStarshipsEnduranceResponse GetStarshipsEndurance(GetStarshipEnduranceRequest request);

    }
}
