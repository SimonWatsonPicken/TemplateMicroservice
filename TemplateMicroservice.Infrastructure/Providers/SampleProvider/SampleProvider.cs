using System.Threading.Tasks;
using TemplateMicroservice.Domain.Aggregates.SampleAggregate;
using TemplateMicroservice.Domain.Providers;

namespace TemplateMicroservice.Infrastructure.Providers.SampleProvider
{
    public class SampleProvider : IProvider<SampleDomainEntity>
    {
        public async Task<SampleDomainEntity> Send(SampleDomainEntity entity)
        {
            return await Task.FromResult(entity);
        }
    }
}