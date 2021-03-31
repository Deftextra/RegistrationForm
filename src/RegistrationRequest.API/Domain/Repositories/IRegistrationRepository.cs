using System.Collections.Generic;
using System.Threading.Tasks;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Domain.Repositories
{
    public interface IRegistrationRepository
    {
        Task<Registration> GetRegistrationByIdAsync(int id);
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
        Task CreateRegistrationAsync(Registration registration);
        void UpdateRegistrationByIdAsync(Registration registration);
    }
}