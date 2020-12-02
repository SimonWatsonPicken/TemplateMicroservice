using System.Threading.Tasks;
using TemplateMicroservice.Domain.Aggregates.SampleAggregate;
using TemplateMicroservice.Domain.Providers;

namespace TemplateMicroservice.Infrastructure.Providers.SampleProvider
{
    public class SampleProvider : IProvider<Author>
    {
        public async Task<Author> Send(Author entity)
        {
            return await Task.FromResult(entity);
        }
    }
}