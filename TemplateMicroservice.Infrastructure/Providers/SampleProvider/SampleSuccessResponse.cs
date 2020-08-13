using Newtonsoft.Json;

namespace TemplateMicroservice.Infrastructure.Providers.SampleProvider
{
    public class SampleSuccessResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("data")]
        public SuccessResponseBody ResponseBody { get; set; }

        public class SuccessResponseBody
        {
            [JsonProperty("tx_id")]
            public string TransactionId { get; set; }
            
            [JsonProperty("tx_status")]
            public int TransactionStatus { get; set; }
        }
    }
}