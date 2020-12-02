using TemplateMicroservice.Domain.Aggregates.SampleAggregate;
using Xunit;

namespace TemplateMicroservice.Tests.UnitTests.Domain
{
    public class SampleDomainEntityShould
    {
        [Fact]
        public void BeValidWhenInstantiatedWithValidValues()
        {
            // Arrange.
            const string name = "Fred";
            const string bio = "25";

            // Act.
            var domainEntity = new Author { Name = name, ShortBiography = bio};

            // Assert.
            Assert.Equal(name, domainEntity.Name);
            Assert.Equal(bio, domainEntity.ShortBiography);
        }
    }
}