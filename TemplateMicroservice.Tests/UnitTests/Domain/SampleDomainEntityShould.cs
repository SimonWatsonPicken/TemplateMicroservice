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
            const int id = 1;
            const string name = "Fred";
            const int age = 25;

            // Act.
            var domainEntity = new SampleDomainEntity() {Id = id, Name = name, Age = age};

            // Assert.
            Assert.Equal(id, domainEntity.Id);
            Assert.Equal(name, domainEntity.Name);
            Assert.Equal(age, domainEntity.Age);
        }
    }
}