using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StarWars.Domain.Models
{
    public class MegalightsPerHour : ValueObject
    {
        public string Value { get; private set; }

        public MegalightsPerHour(string mglt)
        {
            Value = string.IsNullOrEmpty(mglt) ||
                Regex.Match(mglt, @"\b(unknown|n/a)\b").Success ? string.Empty : mglt;            
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Value;
        }
    }
}
