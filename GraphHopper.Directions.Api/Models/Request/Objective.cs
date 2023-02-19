using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Request
{
    public class Objective
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
