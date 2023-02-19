using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Request
{
    public class Shipment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("pickup")]
        public Pickup Pickup { get; set; }

        [JsonProperty("delivery")]
        public Delivery Delivery { get; set; }

        [JsonProperty("size")]
        public List<int> Size { get; set; }

        [JsonProperty("required_skills")]
        public List<string> RequiredSkills { get; set; }
    }
}
