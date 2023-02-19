using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Request
{
    public class StartAddress
    {
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
