using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegistrationRequest.API.Domain.Repositories;
using RegistrationRequest.API.Infrastructure.Persistence;
using RegistrationRequest.API.Infrastructure.Persistence.Repositories;
using RegistrationRequest.API.Mapping;
using Xunit;

namespace RegistrationRequest.Api.UnitTests.Infrastructure.Persistence.Repositories
{
    public class RegistrationRepositoryTests
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IRegistrationRepository _sut;

        public RegistrationRepositoryTests()
        {
            // Create in memory data base
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("FormsDbInMemory");
            var dbContextOptions = builder.Options;

            _appDbContext = new AppDbContext(options: dbContextOptions);
            
            // Delete existing db before creating a new one
            _appDbContext.Database.EnsureDeleted();
            _appDbContext.Database.EnsureCreated();

            if (_mapper == null)
                _mapper = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new DomainToContractProfile());
                        mc.AddProfile(new DtoToDomainProfile());
                    })
                    .CreateMapper();
            
            _sut = new RegistrationRepository(_appDbContext, _mapper);
        }

        [Fact]
        public async Task GetAllRegistrationsAsync_ShouldReturnAllRegistrations_WhenRegistrationsExist()
        {
            
        }
    }
}