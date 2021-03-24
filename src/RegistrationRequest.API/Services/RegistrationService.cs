using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using RegistrationRequest.API.Domain.Models;
using RegistrationRequest.API.Domain.Repositories;

namespace RegistrationRequest.API.Services
{
    public class RegistrationService: IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrationsAsync()
        {
            return await  _registrationRepository.GetAllRegistrationsAsync();
        }
    }
}