using Newtonsoft.Json;

namespace GraphHopper.Directions.Api.Models.Response;

public class ResponseDto
{
    [JsonProperty("copyrights")]
    public List<string> Copyrights { get; set; }

    [JsonProperty("job_id")]
    public string JobId { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("waiting_time_in_queue")]
    public int WaitingTimeInQueue { get; set; }

    [JsonProperty("processing_time")]
    public int ProcessingType { get; set; }

    [JsonProperty("solution")]
    public Solution Solution { get; set; }
}