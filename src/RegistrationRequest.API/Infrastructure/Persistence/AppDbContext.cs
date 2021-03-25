using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RegistrationRequest.API.Domain.Repositories.Models;

namespace RegistrationRequest.API.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RegistrationDto> Registrations { get; set; }
        public DbSet<AddresssDto> Addressses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}