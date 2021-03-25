using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RegistrationRequest.API.Domain.Models;
using RegistrationRequest.API.Domain.Repositories;
using RegistrationRequest.API.Domain.Repositories.Models;

namespace RegistrationRequest.API.Infrastructure.Persistence.Repositories
{
    public class RegistrationRepository : BaseRepository, IRegistrationRepository
    {
        private readonly IMapper _mapper;

        public RegistrationRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            
            _mapper = mapper;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrationsAsync()
        {
            return await _context.Registrations
                .Include(dto => dto.Address)
                .ProjectTo<Registration>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task CreateRegistrationAsync(Registration registration)
        {
            await _context.Registrations.AddAsync(_mapper.Map<Registration, RegistrationDto>(registration));
        }
    }
}