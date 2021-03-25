using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationRequest.API.Domain.Repositories.Models;

namespace RegistrationRequest.API.Infrastructure.Persistence.Configurations
{
    public class AddressDtoConfiguration : IEntityTypeConfiguration<AddresssDto>
    {
        public void Configure(EntityTypeBuilder<AddresssDto> builder)
        {
            builder
                .HasIndex(a => a.Id)
                .IsUnique();
            builder
                .HasKey(a => a.Id);
            builder
                .Property(a => a.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.HasMany(a => a.Registrations)
                .WithOne(r => r.Address)
                .HasForeignKey(r => r.AddressId);
        }
    }
}