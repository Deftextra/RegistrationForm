using AutoMapper;
using RegistrationRequest.API.Contracts.V1.Requests;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Mapping
{
    public class ContractToDomainProfile : Profile
    {
        public ContractToDomainProfile()
        {
            CreateMap<SaveAddressRequest, Address>();
            CreateMap<SaveRegistrationRequest, Registration>();
        }
    }
}