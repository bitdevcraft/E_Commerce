namespace Domain.OrderAggregate
{
    public class Address
    {
        public Address() { }

        public Address(
            string firstName,
            string lastName,
            string street,
            string city,
            string state,
            string zipCode,
            string country
        )
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
