using System.Collections.Generic;
using System.Threading.Tasks;
using RegistrationRequest.API.Contracts.V1.Responses;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Infrastructure.Services
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
        Task<SaveRegistrationResponse> CreateRegistrationAsync(Registration registration);
        Task<Registration> GetRegistrationByIdAsync(int id);
        Task<SaveRegistrationResponse> UpdateRegistrationByIdAsync(int id, Registration registration);
    }
}