using System.Linq;
using Newtonsoft.Json;
using TemplateMicroservice.Infrastructure.Providers.SampleProvider;
using Xunit;

namespace TemplateMicroservice.Tests.UnitTests.Infrastructure
{
    public class SampleErrorResponseShould
    {
        [Fact]
        public void DeserialiseValidJsonToObject()
        {
            // Arrange.
            const string error = "Error";
            const string errorCode = "Error Code";
            const string requestId = "Request Id";
            var validJson = $@"{{'request_id':'{requestId}','errors':[{{'error':'{error}','code':'{errorCode}'}}]}}";

            // Act.
            var errorResponse = JsonConvert.DeserializeObject<SampleErrorResponse>(validJson,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

            // Assert.
            Assert.NotNull(errorResponse);
            Assert.Equal(requestId, errorResponse.RequestId);
            Assert.Equal(error, errorResponse.Errors.First().Error);
            Assert.Equal(errorCode, errorResponse.Errors.First().ErrorCode);
        }
    }
}