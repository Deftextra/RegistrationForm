using System.ComponentModel.DataAnnotations;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Contracts.V1.Requests
{
    public class SaveRegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
        public SaveAddressRequest Address { get; set; }
    }
}