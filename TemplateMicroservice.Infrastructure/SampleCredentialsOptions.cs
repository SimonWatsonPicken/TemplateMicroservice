namespace TemplateMicroservice.Infrastructure
{
    /// <summary>
    /// Example of how settings are used from the appsettings.json file.
    /// </summary>
    /// <remarks>
    /// Go to the ConfigureService method in Startup.cs to see
    /// how DI needs to be configured to inject these options. 
    /// </remarks>
    public class SampleCredentialsOptions
    {
        public const string SampleCredentials = "SampleCredentials";

        public string BaseAddress { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ApiKey { get; set; }
    }
}