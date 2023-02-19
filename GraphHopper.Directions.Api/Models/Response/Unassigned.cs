using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Response;

public class Unassigned
{
    [JsonProperty("services")]
    public List<object> Services { get; set; }

    [JsonProperty("shipments")]
    public List<object> Shipments { get; set; }

    [JsonProperty("breaks")]
    public List<object> Breaks { get; set; }

    [JsonProperty("details")]
    public List<object> Details { get; set; }
}