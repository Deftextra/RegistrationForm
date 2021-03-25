using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationRequest.API.Domain.Repositories.Models;

namespace RegistrationRequest.API.Infrastructure.Persistence.Configurations
{
    public class RegistrationDtoConfigurations : IEntityTypeConfiguration<RegistrationDto>
    {
        public void Configure(EntityTypeBuilder<RegistrationDto> builder)
        {
            builder.HasIndex(r => r.Id)
                .IsUnique();
            builder
                .HasKey(r => r.Id);
            builder
                .Property(r => r.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}