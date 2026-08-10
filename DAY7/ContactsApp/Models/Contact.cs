namespace ContactsApp.Models;

// representing the full Contact stored in memory 
public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Contact(int id, string name, string email, string phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }
}

// Separate model/DTO specifically for taking input from the user (omits the Id)
public class CreateContactDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}