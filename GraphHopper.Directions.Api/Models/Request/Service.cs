using GraphHopper.Directions.Api.Models.Common;
using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Request
{
    public class Service
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("size")]
        public List<int> Size { get; set; }

        [JsonProperty("time_windows")]
        public List<TimeWindow> TimeWindows { get; set; }
    }
}
