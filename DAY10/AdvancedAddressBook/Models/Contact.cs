namespace AdvancedAddressBook.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int AddressBookId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{FirstName} {LastName} | {Address}, {City}, {State} {ZipCode} | {PhoneNumber} | {Email}";
        }
    }
}
