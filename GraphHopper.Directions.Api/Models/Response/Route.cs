using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Response;

public class Route
{
    [JsonProperty("vehicle_id")]
    public string VehicleId { get; set; }

    [JsonProperty("distance")]
    public int Distance { get; set; }

    [JsonProperty("transport_time")]
    public int TransportTime { get; set; }

    [JsonProperty("completion_time")]
    public int CompletionTime { get; set; }

    [JsonProperty("waiting_time")]
    public int WaitingTime { get; set; }

    [JsonProperty("service_duration")]
    public int ServiceDuration { get; set; }

    [JsonProperty("preparation_time")]
    public int PreparationTime { get; set; }

    [JsonProperty("points")]
    public List<Point> Points { get; set; }

    [JsonProperty("activities")]
    public List<Activity> Activities { get; set; }
}