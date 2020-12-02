using TemplateMicroservice.Domain.Aggregates.SampleAggregate;

namespace TemplateMicroservice.Tests.ObjectMothers
{
   internal class SampleDomainEntityMother
    {
        public static Author GetValidSampleDomainEntity()
        {
            return new Author {Name = "Fred", ShortBiography = "25"};
        }
    }
}