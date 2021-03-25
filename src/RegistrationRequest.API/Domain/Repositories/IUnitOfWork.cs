using System.Threading.Tasks;

namespace RegistrationRequest.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

    }
}