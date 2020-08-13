using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TemplateMicroservice.Infrastructure;
using Xunit;

namespace TemplateMicroservice.Tests.IntegrationTests
{
  public  class SampleCredentialsOptionsShould
    {
        private readonly IServiceProvider _serviceProvider;

        public SampleCredentialsOptionsShould()
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            var configuration = configBuilder.Build();

            // SetUp DI
            var services = new ServiceCollection();
            services.AddOptions();  // This is required to use IOption Pattern.

            services.Configure<SampleCredentialsOptions>(configuration.GetSection("SampleCredentials"));
            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public void GetEmailCredentialsFromAppSettings()
        {
            // Arrange.
            // Act.
            var options = _serviceProvider.GetService<IOptions<SampleCredentialsOptions>>().Value;

            // Assert.
            Assert.NotNull(options);
            Assert.False(string.IsNullOrWhiteSpace(options.ApiKey));
            Assert.False(string.IsNullOrWhiteSpace(options.BaseAddress));
            Assert.False(string.IsNullOrWhiteSpace(options.UserName));
            Assert.False(string.IsNullOrWhiteSpace(options.Password));
        }
    }
}