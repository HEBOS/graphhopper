using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Common
{
    public class Address
    {
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
