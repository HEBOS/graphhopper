using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Request
{
    public class Routing
    {
        [JsonProperty("calc_points")]
        public bool CalculationPoints { get; set; }

        [JsonProperty("snap_preventions")]
        public List<string> SnapPreventions { get; set; }
    }
}
