using System.ComponentModel;
using AutoMapper;
using RegistrationRequest.API.Contracts.V1.Requests;
using RegistrationRequest.API.Contracts.V1.Responses;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Mapping
{
    public class DomainToContractProfile : Profile
    {
        public DomainToContractProfile()
        {
            CreateMap<Registration, RegistrationResponse>();
        }
    }
}