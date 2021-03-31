using System.Collections.Generic;

namespace RegistrationRequest.API.Domain.Repositories.Models
{
    public class AddresssDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public IList<RegistrationDto> Registrations { get; set; } = new List<RegistrationDto>();
    }
}