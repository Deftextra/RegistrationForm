namespace RegistrationRequest.API.Contracts.V1.Responses
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}