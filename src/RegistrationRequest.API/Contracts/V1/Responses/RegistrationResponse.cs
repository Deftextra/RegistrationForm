using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Contracts.V1.Responses
{
    public class RegistrationResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
    }
}