using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
                Regex.IsMatch(mglt, @"\b(unknown|n/a)\b",RegexOptions.IgnoreCase) ? string.Empty : mglt;            
        }

        [ExcludeFromCodeCoverage]
        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Value;
        }
    }
}
