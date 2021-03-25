#nullable enable
using System.ComponentModel.DataAnnotations;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Contracts.V1.Requests
{
    public class UpdateRegistrationRequest
    {
        [Required]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? EmailAddress { get; set; }
        public Address? Address { get; set; }
    }
}