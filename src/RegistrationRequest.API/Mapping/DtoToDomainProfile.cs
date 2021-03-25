using AutoMapper;
using RegistrationRequest.API.Domain.Models;
using RegistrationRequest.API.Domain.Repositories.Models;

namespace RegistrationRequest.API.Mapping
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<RegistrationDto, Registration>();
            CreateMap<AddresssDto, AddresssDto>();
        }
    }
}