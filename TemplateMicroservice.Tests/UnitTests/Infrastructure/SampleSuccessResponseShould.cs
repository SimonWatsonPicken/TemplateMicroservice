using Newtonsoft.Json;
using TemplateMicroservice.Infrastructure.Providers.SampleProvider;
using Xunit;

namespace TemplateMicroservice.Tests.UnitTests.Infrastructure
{
    public class SampleSuccessResponseShould
    {
        [Fact]
        public void DeserialiseValidJsonToObject()
        {
            // Arrange,
            const string requestId = "Request Id";
            const string transactionId = "Transaction Id";
            const int transactionStatus = 1;
            var validJson = $@"{{'data':{{'tx_id': '{transactionId}','tx_status': {transactionStatus}}},'request_id':'{requestId}'}}";

            // Act.
            var successResponse = JsonConvert.DeserializeObject<SampleSuccessResponse>(validJson,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

            // Assert.
            Assert.NotNull(successResponse);
            Assert.Equal(requestId, successResponse.RequestId);
            Assert.Equal(transactionId, successResponse.ResponseBody.TransactionId);
            Assert.Equal(transactionStatus, successResponse.ResponseBody.TransactionStatus);
        }
    }
}