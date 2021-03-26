#nullable enable
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Contracts.V1.Requests
{
    public class UpdateRegistrationRequest
    {
        [Required]
        [FromRoute]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? EmailAddress { get; set; }
        public Address Address { get; set; }
    }
}