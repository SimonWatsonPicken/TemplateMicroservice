using System.Threading.Tasks;
using TemplateMicroservice.Api.Application.Model;

namespace TemplateMicroservice.Api.Application.Handlers
{
    public interface ICommandHandler<in T>
    {
        Task<SampleUiEntity> Handle(T command);
    }
}