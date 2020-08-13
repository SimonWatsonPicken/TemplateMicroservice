using System.Threading.Tasks;

namespace TemplateMicroservice.Domain.Providers
{
    public interface IProvider<T>
    {
        Task<T> Send(T entity);
    }
}