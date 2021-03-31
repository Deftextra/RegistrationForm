using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using RegistrationRequest.API.Domain.Models;
using RegistrationRequest.API.Domain.Repositories;
using RegistrationRequest.API.Infrastructure.Services;
using Xunit;

namespace RegistrationRequest.Api.UnitTests.Infrastructure.Services
{
    public class RegistrationServiceTests
    {
        private readonly Mock<IRegistrationRepository> _registrationRepoMock = new();
        private readonly IRegistrationService _sut;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();


        public RegistrationServiceTests()
        {
            _sut = new RegistrationService(_registrationRepoMock.Object, _unitOfWorkMock.Object);
        }

        [Theory]
        [MemberData(nameof(RegistrationServiceData.GetRegistrationsTestData), 1,
            MemberType = typeof(RegistrationServiceData))]
        public async Task GetAllRegistration_ShouldReturnAllRegistrations_WhenRegistrationsExist(
            IList<Registration> registrations, IList<Registration> expectedRegistrations)
        {
            // Arrange
            _registrationRepoMock.Setup(s => s.GetAllRegistrationsAsync())
                .ReturnsAsync(registrations);

            // Act
            var registrationsResult = await _sut.GetAllRegistrationsAsync();

            // Assert
            registrationsResult.Should().BeEquivalentTo(expectedRegistrations);
        }
    }

    public class RegistrationServiceData
    {
        private static IEnumerable<Registration> Registrations =>
            new List<Registration>
            {
                new()
                {
                    Id = 1,
                    FirstName = "Radwan",
                    LastName = "Suufi",
                    Address = Addresses.First()
                },

                new()
                {
                    Id = 2,
                    FirstName = "Rayan",
                    LastName = "Suufi",
                    Address = Addresses.First()
                }
            };

        private static IEnumerable<Address> Addresses =>
            new List<Address>
            {
                new()
                {
                    Id = 1,
                    City = "Birmingham",
                    Country = "UK",
                    State = "West Midlands",
                    Street = "126 Tyburn Road",
                    PostalCode = "B11 3bj"
                }
            };

        public static IEnumerable<object[]> GetRegistrationsTestData(int numTests = 1)
        {
            var testData = new List<object[]>
            {
                new object[] {Registrations, Registrations}
            };

            return testData.Take(numTests);
        }
    }
}