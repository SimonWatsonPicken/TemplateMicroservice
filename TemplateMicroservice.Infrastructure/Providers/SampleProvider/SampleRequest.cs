using Newtonsoft.Json;

namespace TemplateMicroservice.Infrastructure.Providers.SampleProvider
{
   public class SampleRequest
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }
}