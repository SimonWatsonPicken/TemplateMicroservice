using System.Threading.Tasks;

namespace TemplateMicroservice.Api.Application.Handlers
{
    public interface ICommandHandler<in T>
    {
        Task<bool> Handle(T command);
    }
}