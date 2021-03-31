using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistrationRequest.API.Contracts.V1.Responses;
using RegistrationRequest.API.Domain.Models;
using RegistrationRequest.API.Domain.Repositories;

namespace RegistrationRequest.API.Infrastructure.Services
{
    public class RegistrationService : IRegistrationService
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
            return await _registrationRepository.GetAllRegistrationsAsync();
        }

        public async Task<SaveRegistrationResponse> CreateRegistrationAsync(Registration registration)
        {
            try
            {
                await _registrationRepository.CreateRegistrationAsync(registration);
                await _unitOfWork.CompleteAsync();

                return new SaveRegistrationResponse(registration);
            }
            catch (Exception ex)
            {
                return new SaveRegistrationResponse(
                    $"An error occured during creation of the registration: {ex.Message}");
            }
        }

        public async Task<Registration> GetRegistrationByIdAsync(int id)
        {
            return await _registrationRepository.GetRegistrationByIdAsync(id);
        }

        public async Task<SaveRegistrationResponse> UpdateRegistrationByIdAsync(int id, Registration registration)
        {
            try
            {
                _registrationRepository.UpdateRegistrationByIdAsync(registration);
                await _unitOfWork.CompleteAsync();

                return new SaveRegistrationResponse(registration);
            }
            catch (Exception ex)
            {
                return new SaveRegistrationResponse(
                    $"An error occured during update of the registration: {ex.Message}");
            }
        }
    }
}