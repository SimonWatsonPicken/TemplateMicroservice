using TemplateMicroservice.Domain.Aggregates.SampleAggregate;

namespace TemplateMicroservice.Api.Application.Commands
{
    public class SampleCommand
    {
        public string Name { get; set; }

        public Author ConvertToDomainEntity()
        {
            return new Author {Name = Name};
        }
    }
}