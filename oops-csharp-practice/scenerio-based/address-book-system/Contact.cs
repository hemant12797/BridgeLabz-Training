internal class Contact
{
    private string FirstName;
    private string LastName;
    private string City;
    private string State;
    private string ZipCode;
    private string PhoneNumber;
    private string Email;

    public Contact(string firstName, string lastName, string city, string state, string zipCode, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        City = city;
        State = state;
        ZipCode = zipCode;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    // Getters and Setter for all the fields
    public string GetFirstName()
    {
        return FirstName;
    }

    public void SetFirstName(string firstName)
    {
        FirstName = firstName;
    }

    public string GetLastName()
    {
        return LastName;
    }
    
    public void SetLastName(string lastName)
    {
        LastName = lastName;
    }

    public string GetCity()
    {
        return City;
    }

    public void SetCity(string city)
    {
        City = city;
    }

    public string GetState()
    {
        return State;
    }

    public void SetState(string state)
    {
        State = state;
    }

    public string GetZipCode()
    {
        return ZipCode;
    }

    public void SetZipCode(string zipCode)
    {
        ZipCode = zipCode;
    }

    public string GetPhoneNumber()
    {
        return PhoneNumber;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public string GetEmail()
    {
        return Email;
    }

    public void SetEmail(string email)
    {
        Email = email;
    }

    // Overriding ToString to allow printing a Contact
    public override string ToString()
    {
        return $"\nFirst Name: {FirstName} | Last Name: {LastName} | City: {City} | State: {State} | Zip Code: {ZipCode} | Phone Number: {PhoneNumber} | Email: {Email}";
    }
    
}