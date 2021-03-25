using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using RegistrationRequest.API.Contracts.V1.Responses;
using RegistrationRequest.API.Domain.Models;
using RegistrationRequest.API.Mapping;
using Xunit;

namespace RegistrationRequest.Api.UnitTests.Mapper
{
    public class MappingProfilesTest
    {
        public readonly IMapper _sut;

        public MappingProfilesTest()
        {
            if (_sut == null)
                _sut = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new DomainToContractProfile());
                        mc.AddProfile(new DtoToDomainProfile());
                    })
                    .CreateMapper();
        }



        [Theory]
        [MemberData(nameof(AddressMappingData))]
        public async Task Mapper_MapsAddresssToAddressResponse_WhenModelsValid(Address address,
            AddressResponse expectedAddress)
        {
            // Arrange

            // Act
            var result = _sut.Map<Address, AddressResponse>(address);
            //Assert
            result.Should().BeEquivalentTo(expectedAddress);
        }
        
        public static IEnumerable<object[]> AddressMappingData =>
            new List<object[]>
            {
                new object[]
                {
                    new Address
                    {
                        Id = 1,
                        Country = "Uk",
                        City = "Birmingham",
                        State = "West Midlands",
                        Street = "Victoriana Way",
                        PostalCode = "B11 6bj"
                    },

                    new AddressResponse
                    {
                        Id = 1,
                        Country = "Uk",
                        City = "Birmingham",
                        State = "West Midlands",
                        Street = "Victoriana Way",
                        PostalCode = "B11 6bj"
                    }
                }
            };
    }
}