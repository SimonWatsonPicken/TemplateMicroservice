using TemplateMicroservice.Api.Application.Commands;
using Xunit;

namespace TemplateMicroservice.Tests.UnitTests.Application
{
    public class DomainExtensionsShould
    {
        [Fact]
        public void ReturnADomainEntityIfCommandIsNotNull()
        {
            // Arrange.
            const string name = "Simon";
            var command = new SampleCommand {Name = name};

            // Act.
            var domainEntity = command.ConvertToDomainEntity();

            // Assert.
            Assert.NotNull(domainEntity);
            Assert.Equal(name, domainEntity.Name);
        }
    }
}