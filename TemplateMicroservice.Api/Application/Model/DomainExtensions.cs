using TemplateMicroservice.Api.Application.Commands;
using TemplateMicroservice.Domain.Aggregates.SampleAggregate;

namespace TemplateMicroservice.Api.Application.Model
{
    /// <summary>
    /// Extension methods to map between command objects and domain entities.
    /// Note: There is likely to be fewer properties in the command than in the domain entity.
    /// </summary>
    public static class DomainExtensions
    {
        public static SampleDomainEntity ToDomainEntity(this SampleCommand command)
        {
            if (command == null) return null;

            return new SampleDomainEntity
            {
                Id = command.Id,
                Name = command.Name
            };
        }
    }
}