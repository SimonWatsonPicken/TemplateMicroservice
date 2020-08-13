using TemplateMicroservice.Domain.Aggregates.SampleAggregate;
using TemplateMicroservice.Infrastructure.Providers.SampleProvider;
using TemplateMicroservice.Tests.ObjectMothers;
using Xunit;

namespace TemplateMicroservice.Tests.UnitTests.Infrastructure
{
    public class SampleProviderShould
    {
        [Fact]
        public void ReturnASuccessResponseForAValidDomainEntity()
        {
            // Arrange.
            var provider = new SampleProvider();
            var domainEntity = SampleDomainEntityMother.GetValidSampleDomainEntity();

            // Act.
            var result = provider.Send(domainEntity).Result;

            // Assert.
            Assert.IsType<SampleDomainEntity>(result);
        }
    }
}