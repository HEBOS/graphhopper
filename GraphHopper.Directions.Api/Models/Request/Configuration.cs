using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Request
{
    public class Configuration
    {
        [JsonProperty("routing")]
        public Routing Routing { get; set; }
    }
}
