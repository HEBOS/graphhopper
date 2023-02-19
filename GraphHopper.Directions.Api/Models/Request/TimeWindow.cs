using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Request
{
    public class TimeWindow
    {
        [JsonProperty("earliest")]
        public int Earliest { get; set; }

        [JsonProperty("latest")]
        public int Latest { get; set; }
    }
}
