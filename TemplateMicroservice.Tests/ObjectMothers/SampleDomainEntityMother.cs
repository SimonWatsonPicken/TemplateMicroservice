using TemplateMicroservice.Domain.Aggregates.SampleAggregate;

namespace TemplateMicroservice.Tests.ObjectMothers
{
   internal class SampleDomainEntityMother
    {
        public static SampleDomainEntity GetValidSampleDomainEntity()
        {
            return new SampleDomainEntity {Id = 1, Name = "Fred", Age = 25};
        }
    }
}