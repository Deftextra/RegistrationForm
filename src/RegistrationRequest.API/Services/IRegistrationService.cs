using System.Collections.Generic;
using System.Threading.Tasks;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Services
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
        // Task<Registration> CreateRegistrationAsync(Registration registration);
        // Task<Registration> GetRegistrationByIdAsync(int id);
        // Task<Registration> UpDateRegistration();
    }
}