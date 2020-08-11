using TemplateMicroservice.Api.Application.Commands;
using TemplateMicroservice.Api.Application.Model;
using Xunit;

namespace TemplateMicroservice.Tests.UnitTests.Application
{
    public class DomainExtensionsShould
    {
        [Fact]
        public void ReturnNullIfCommandIsNull()
        {
            // Arrange.
            SampleCommand command = null;

            // Act.
            // ReSharper disable once ExpressionIsAlwaysNull
            var domainEntity = command.ToDomainEntity();

            // Assert.
            Assert.Null(domainEntity);
        }
        
        [Fact]
        public void ReturnADomainEntityIfCommandIsNotNull()
        {
            // Arrange.
            const int id = 1;
            const string name = "Simon";
            var command = new SampleCommand {Id = id, Name = name};

            // Act.
            var domainEntity = command.ToDomainEntity();

            // Assert.
            Assert.NotNull(domainEntity);
            Assert.Equal(id, domainEntity.Id);
            Assert.Equal(name, domainEntity.Name);
        }
    }
}