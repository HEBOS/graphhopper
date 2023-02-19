using GraphHopper.Directions.Api.Models.Common;
using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Request
{
    public class Pickup
    {
        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
