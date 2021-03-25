namespace RegistrationRequest.API.Contracts.V1.Responses
{
    public class RegistrationResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public AddressResponse Address { get; set; }
    }
}