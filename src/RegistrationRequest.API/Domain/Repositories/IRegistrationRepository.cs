using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RegistrationRequest.API.Contracts.V1.Responses;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Domain.Repositories
{
    public interface IRegistrationRepository
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
        Task CreateRegistrationAsync(Registration registration);
    }
}