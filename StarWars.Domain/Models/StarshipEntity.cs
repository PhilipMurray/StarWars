using System.Text.RegularExpressions;

namespace StarWars.Domain.Models
{
    public class StarshipEntity : Entity
    {
        // Using private fields is a much better encapsulation
        // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)
        private string _name;
        private MegalightsPerHour _megalightsPerHour;
        private string _consumables;


        public StarshipEntity(string name, string mGLT, string consumables)
        {
            _name = string.IsNullOrEmpty(name)
                    || Regex.IsMatch(name, @"\b(unknown|n/a)\b", RegexOptions.IgnoreCase) ? string.Empty : name;

            _megalightsPerHour = new MegalightsPerHour(mGLT);

            _consumables = string.IsNullOrEmpty(consumables)
                           || Regex.IsMatch(consumables, @"\b(unknown|n/a)\b", RegexOptions.IgnoreCase) ? string.Empty : consumables;
        }

        public string GetName()
        {
            return _name;
        }

        public int? GetMGLT()
        {
            bool success = int.TryParse(_megalightsPerHour.Value, out int result);

            if (success)
                return result;
            else
                return null;
        }

        public string GetConsumables()
        {
            return _consumables;
        }
    }
}
