using ContactsApp.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In-memory data store using the Contact model
var contacts = new List<Contact>
{
    new Contact(1, "John Doe", "john@example.com", "555-0100"),
    new Contact(2, "Jane Smith", "jane@example.com", "555-0200")
};

// 1. Get All Contacts
app.MapGet("/api/contacts", () => contacts);

// 2. Get Contact by ID
app.MapGet("/api/contacts/{id}", (int id) =>
{
    var contact = contacts.FirstOrDefault(c => c.Id == id);
    return contact is not null ? Results.Ok(contact) : Results.NotFound();
});

// 3. Create a New Contact (Using CreateContactDto for input)
app.MapPost("/api/contacts", (CreateContactDto input) =>
{
    if (string.IsNullOrWhiteSpace(input.Name))
    {
        return Results.BadRequest("Name is required.");
    }

    var nextId = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1;

    var contact = new Contact(nextId, input.Name, input.Email, input.Phone);
    contacts.Add(contact);

    return Results.Created($"/api/contacts/{contact.Id}", contact);
});

// 4. Update an Existing Contact
app.MapPut("/api/contacts/{id}", (int id, CreateContactDto input) =>
{
    var contact = contacts.FirstOrDefault(c => c.Id == id);
    if (contact is null) return Results.NotFound();

    contact.Name = input.Name;
    contact.Email = input.Email;
    contact.Phone = input.Phone;

    return Results.NoContent();
});

// 5. Delete a Contact
app.MapDelete("/api/contacts/{id}", (int id) =>
{
    var contact = contacts.FirstOrDefault(c => c.Id == id);
    if (contact is null) return Results.NotFound();

    contacts.Remove(contact);
    return Results.NoContent();
});

app.Run();