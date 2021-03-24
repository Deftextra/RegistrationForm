using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Domain.Repositories
{
    public interface IRegistrationRepository
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
    }
}