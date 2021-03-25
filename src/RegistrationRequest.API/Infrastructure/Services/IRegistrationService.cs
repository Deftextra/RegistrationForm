using System.Collections.Generic;
using System.Threading.Tasks;
using RegistrationRequest.API.Contracts.V1.Responses;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Infrastructure.Services
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
        Task<CreateRegistrationResponse> CreateRegistrationAsync(Registration registration);
        // Task<Registration> GetRegistrationByIdAsync(int id);
        // Task<Registration> UpDateRegistration();
    }
}