using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Response;

public class Point
{
    [JsonProperty("coordinates")]
    public List<List<double>> Coordinates { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}