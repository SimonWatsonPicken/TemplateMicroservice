using System.Collections.Generic;
using Newtonsoft.Json;

namespace TemplateMicroservice.Infrastructure.Providers.SampleProvider
{
    public class SampleErrorResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("errors")]
        public List<ErrorResponseBody> Errors { get; set; }
    }

    public class ErrorResponseBody
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("code")]
        public string ErrorCode { get; set; }

    }
}