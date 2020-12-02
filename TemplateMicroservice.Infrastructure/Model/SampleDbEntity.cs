using System;
using TemplateMicroservice.Domain.Aggregates.SampleAggregate;

namespace TemplateMicroservice.Infrastructure.Model
{
   public class SampleDbEntity : IDbEntity<Author>
    {
        public Author ConvertToDomainEntity()
        {
            throw new NotImplementedException();
        }
    }
}