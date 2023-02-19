using GraphHopper.Directions.Api.Models.Common;
using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Response
{
    public class Activity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("end_time")]
        public int EndTime { get; set; }

        [JsonProperty("end_date_time")]
        public object EndDateTime { get; set; }

        [JsonProperty("distance")]
        public int Distance { get; set; }

        [JsonProperty("driving_time")]
        public int DrivingTime { get; set; }

        [JsonProperty("preparation_time")]
        public int PreparationTime { get; set; }

        [JsonProperty("waiting_time")]
        public int WaitingTime { get; set; }

        [JsonProperty("load_before")]
        public List<int> LoadBefore { get; set; }

        [JsonProperty("load_after")]
        public List<int> LoadAfter { get; set; }

        [JsonProperty("arr_time")]
        public int? ArrivalTime { get; set; }

        [JsonProperty("arr_date_time")]
        public object ArrivalDateTime { get; set; }
    }
}
