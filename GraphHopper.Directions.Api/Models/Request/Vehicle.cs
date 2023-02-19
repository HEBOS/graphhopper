using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Request
{
    public class Vehicle
    {
        [JsonProperty("vehicle_id")]
        public string VehicleId { get; set; }

        [JsonProperty("type_id")]
        public string TypeId { get; set; }

        [JsonProperty("start_address")]
        public StartAddress StartAddress { get; set; }

        [JsonProperty("earliest_start")]
        public int EarliestStart { get; set; }

        [JsonProperty("latest_end")]
        public int LatestEnd { get; set; }

        [JsonProperty("max_jobs")]
        public int MaxJobs { get; set; }

        [JsonProperty("skills")]
        public List<string> Skills { get; set; }
    }
}
