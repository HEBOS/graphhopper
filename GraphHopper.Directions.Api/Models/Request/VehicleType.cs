using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Request
{
    public class VehicleType
    {
        [JsonProperty("type_id")]
        public string TypeId { get; set; }

        [JsonProperty("capacity")]
        public List<int> Capacity { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }
    }
}
