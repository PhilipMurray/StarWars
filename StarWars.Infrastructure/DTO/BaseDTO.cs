using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Infrastructure.DTO
{
    public abstract class BaseDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

    }
}
