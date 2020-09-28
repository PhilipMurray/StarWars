using StarWars.Infrastructure.DTO;

namespace StarWars.Infrastructure.Interfaces
{
    public interface IApiContext
    {

        public string Get(string apiResource);
    }
}
