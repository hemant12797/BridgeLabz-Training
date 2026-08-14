namespace AdvancedAddressBook.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} | {City}, {State} | {PhoneNumber} | {Email}";
        }
    }
}
