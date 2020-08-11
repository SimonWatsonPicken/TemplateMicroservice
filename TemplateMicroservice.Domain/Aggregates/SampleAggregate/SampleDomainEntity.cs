using TemplateMicroservice.Domain.SeedWork;

namespace TemplateMicroservice.Domain.Aggregates.SampleAggregate
{
    public class SampleDomainEntity : IAggregateRoot
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}