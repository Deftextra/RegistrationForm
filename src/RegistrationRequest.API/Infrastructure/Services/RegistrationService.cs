using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using RegistrationRequest.API.Contracts.V1.Responses;
using RegistrationRequest.API.Domain.Models;
using RegistrationRequest.API.Domain.Repositories;

namespace RegistrationRequest.API.Infrastructure.Services
{
    public class RegistrationService: IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationService(IRegistrationRepository registrationRepository, IUnitOfWork unitOfWork)
        {
            _registrationRepository = registrationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrationsAsync()
        {
            return await  _registrationRepository.GetAllRegistrationsAsync();
        }

        public async Task<CreateRegistrationResponse> CreateRegistrationAsync(Registration registration)
        {
            try
            {
                await _registrationRepository.CreateRegistrationAsync(registration);
                await _unitOfWork.CompleteAsync();

                return new CreateRegistrationResponse(registration);

            }
            catch (Exception ex)
            {
                return new CreateRegistrationResponse(
                    $"An error occured during creation of the registration: {ex.Message}");
            }
        }

    }
}