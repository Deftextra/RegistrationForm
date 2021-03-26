using AutoMapper;
using RegistrationRequest.API.Domain.Models;
using RegistrationRequest.API.Domain.Repositories.Models;

namespace RegistrationRequest.API.Mapping
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Registration, RegistrationDto>();
            CreateMap<Address, AddresssDto>();
       }
    }
}