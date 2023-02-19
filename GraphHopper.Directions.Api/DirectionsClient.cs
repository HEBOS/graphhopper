using GraphHopper.Directions.Api.Models;
using GraphHopper.Directions.Api.Models.Request;
using GraphHopper.Directions.Api.Models.Response;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace GraphHopper.Directions.Api
{
    public class DirectionsClient
    {
        private readonly string _apiKey;
        private const string DefaultUrl = "https://graphhopper.com";
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public DirectionsClient(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            _apiKey = apiKey;
            _baseUrl = DefaultUrl;
            _client = new HttpClient();
        }

        public DirectionsClient(string baseUrl, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            _apiKey = apiKey;
            _baseUrl = baseUrl.EndsWith("/") ? baseUrl.Remove(baseUrl.Length - 1) : baseUrl;
            _client = new HttpClient();
        }

        public DirectionsClient(HttpMessageHandler handler, string apiKey)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            _apiKey = apiKey;
            _baseUrl = DefaultUrl;
            _client = new HttpClient(handler);
        }

        public async Task<(ResponseCode, ResponseDto?, string?)> OptimizeRoute(RequestDto requestDto, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, string.Format(_baseUrl, _apiKey));

            var content = JsonConvert.SerializeObject(requestDto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsync(string.Concat(_baseUrl, $"/api/1/vrp?key={_apiKey}"), byteContent, cancellationToken);
            }
            catch (TaskCanceledException e)
            {
                return (ResponseCode.Cancelled, null, "Data received from directions provider is empty.");
            }
            
            if (!response.IsSuccessStatusCode)
            {
                return (
                    response.StatusCode == HttpStatusCode.InternalServerError
                        ? ResponseCode.InternalServerError
                        : ResponseCode.BadRequest, null, null);
            }

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                return (ResponseCode.EmptyResponse, null, "Data received from directions provider is empty.");
            }

            return (ResponseCode.Success, JsonConvert.DeserializeObject<ResponseDto>(responseContent), null);
        }
    }
}
