using FluentAssertions;
using GraphHopper.Directions.Api;
using GraphHopper.Directions.Api.Models;
using GraphHopper.Directions.Api.Models.Request;
using Newtonsoft.Json;

namespace GraphHopper.Integration.Tests
{
    public class HealthTests
    {
        private const string ApiKey = "sample-api-key";

        private const string TestData =
            "{\n  \"vehicles\": [\n    {\n      \"vehicle_id\": \"my_vehicle\",\n      \"start_address\": {\n        \"location_id\": \"berlin\",\n        \"lon\": 13.406,\n        \"lat\": 52.537\n      }\n    }\n  ],\n  \"services\": [\n    {\n      \"id\": \"hamburg\",\n      \"name\": \"visit_hamburg\",\n      \"address\": {\n        \"location_id\": \"hamburg\",\n        \"lon\": 9.999,\n        \"lat\": 53.552\n      }\n    },\n    { \n     \"id\": \"munich\",\n      \"name\": \"visit_munich\",\n      \"address\": {\n        \"location_id\": \"munich\",\n        \"lon\": 11.57,\n        \"lat\": 48.145\n      }\n    }\n  ]}";

        [Fact]
        public async Task TestHealth()
        {
            var client = new DirectionsClient(ApiKey);
#pragma warning disable CS8604
            var response = await client.OptimizeRoute(JsonConvert.DeserializeObject<RequestDto>(TestData),
#pragma warning restore CS8604
                CancellationToken.None);

            response.Item1.Should().Be(ResponseCode.Success);
            response.Item2.Should().NotBeNull();
            response.Item3.Should().BeNull();
        }
    }
}