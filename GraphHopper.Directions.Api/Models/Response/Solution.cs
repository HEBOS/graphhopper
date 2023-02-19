using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Response;

public class Solution
{
    [JsonProperty("costs")]
    public int Costs { get; set; }

    [JsonProperty("distance")]
    public int Distance { get; set; }

    [JsonProperty("time")]
    public int Time { get; set; }

    [JsonProperty("transport_time")]
    public int TransportTime { get; set; }

    [JsonProperty("completion_time")]
    public int CompletionTime { get; set; }

    [JsonProperty("max_operation_time")]
    public int MaxOperationTime { get; set; }

    [JsonProperty("waiting_time")]
    public int WaitingTime { get; set; }

    [JsonProperty("service_duration")]
    public int ServiceDuration { get; set; }

    [JsonProperty("preparation_time")]
    public int PreparationTime { get; set; }

    [JsonProperty("no_vehicles")]
    public int NoVehicles { get; set; }

    [JsonProperty("no_unassigned")]
    public int NoUnassigned { get; set; }

    [JsonProperty("routes")]
    public List<Route> Routes { get; set; }

    [JsonProperty("unassigned")]
    public Unassigned Unassigned { get; set; }
}