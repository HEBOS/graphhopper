using System;
using System.Net;
using FluentAssertions;
using GraphHopper.Directions.Api;
using GraphHopper.Directions.Api.Models;
using GraphHopper.Directions.Api.Models.Request;
using GraphHopper.Directions.Api.Models.Response;
using Moq.Protected;
using Moq;
using Newtonsoft.Json;

namespace GraphHopper.Unit.Tests
{
    public class DirectionsClientTests
    {
        private const string MockedKey = "mocked-key";

        [Fact]
        public void CreateClientWithoutApiKeyReturnsArgumentException()
        {
            var invokeAction = () => { var client = new DirectionsClient(string.Empty); };
            invokeAction.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData("", "key")]
        [InlineData("url", "")]
        [InlineData("", "")]
        public void CreateClientWithoutApiKeyAndBaseUrlReturnsArgumentException(string baseUrl, string apiKey)
        {
            var invokeAction = () => { _ = new DirectionsClient(baseUrl, apiKey); };
            invokeAction.Should().Throw<Exception>();
        }

        [Fact]
        public void CreateClientWithApiKeyAndBaseUrlDoesNotRaiseException()
        {
            var mockedHandler = CreateHandler(HttpStatusCode.OK, new ResponseDto());
            var invokeAction = () => { _ = new DirectionsClient(mockedHandler.Object, MockedKey); };
            invokeAction.Should().NotThrow<Exception>();
        }

        [Fact]
        public async Task OptimizeCallReturnsOk()
        {
            var mockedHandler = CreateHandler(HttpStatusCode.OK, new ResponseDto());
            var client = new DirectionsClient(mockedHandler.Object, MockedKey);
            var optimizeResult = await client.OptimizeRoute(new RequestDto(), CancellationToken.None);
            optimizeResult.Item1.Should().Be(ResponseCode.Success);
            optimizeResult.Item2.Should().NotBeNull();
            optimizeResult.Item3.Should().BeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, ResponseCode.BadRequest, null)]
        [InlineData(HttpStatusCode.InternalServerError, ResponseCode.InternalServerError, null)]
        [InlineData(HttpStatusCode.OK, ResponseCode.EmptyResponse, null)]
        [InlineData(HttpStatusCode.OK, ResponseCode.Cancelled, null)]
        public async Task OptimizeCallReturnsError(HttpStatusCode httpStatusCode, ResponseCode responseCode, ResponseDto? expectedResponseDto)
        {
            var mockedHandler = CreateHandler(httpStatusCode, expectedResponseDto);
            var client = new DirectionsClient(mockedHandler.Object, MockedKey);
            var cancellationTokenSource = new CancellationTokenSource();

            if (responseCode == ResponseCode.Cancelled)
            {
                cancellationTokenSource.Cancel();
            }
            
            var optimizeResult = await client.OptimizeRoute(new RequestDto(), cancellationTokenSource.Token);
            optimizeResult.Item1.Should().Be(responseCode);
            optimizeResult.Item2.Should().BeNull();
            if (responseCode is ResponseCode.EmptyResponse or ResponseCode.Cancelled)
            {
                optimizeResult.Item3.Should().NotBeNull();
            }
            else
            {
                optimizeResult.Item3.Should().BeNull();
            }
            
        }

        private Mock<HttpMessageHandler> CreateHandler(HttpStatusCode responseStatus, ResponseDto? expectedResponse)
        {
            var handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns(Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(responseStatus)
                {
                    Content = expectedResponse == null ? null : new StringContent(JsonConvert.SerializeObject(expectedResponse))
                }))
                .Callback<HttpRequestMessage, CancellationToken>((r, c) =>
                {
                    HttpMethod.Post.Should().BeEquivalentTo(r.Method);
                });

            return handler;
        }
    }
}