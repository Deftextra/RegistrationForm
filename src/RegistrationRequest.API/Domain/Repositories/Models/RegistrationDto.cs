using System.ComponentModel.DataAnnotations;

namespace RegistrationRequest.API.Domain.Repositories.Models
{
    public class RegistrationDto
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50) ]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(50)]
        public string EmailAddress { get; set; }
        public int AddressId { get; set; }
        public AddresssDto Address { get; set; }
    }
}