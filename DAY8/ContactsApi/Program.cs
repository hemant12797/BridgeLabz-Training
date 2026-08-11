using ContactsApi.Data;
using ContactsApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository
builder.Services.AddSingleton<ContactRepository>();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

// GET ALL
app.MapGet("/contacts", (ContactRepository repo) =>
{
    return Results.Ok(repo.GetAll());
});

// GET BY ID
app.MapGet("/contacts/{id:int}", (int id, ContactRepository repo) =>
{
    var contact = repo.GetById(id);
    return contact is null ? Results.NotFound() : Results.Ok(contact);
});

// CREATE
app.MapPost("/contacts", (Contact contact, ContactRepository repo) =>
{
    repo.Add(contact);
    return Results.Created("/contacts", contact);
});

// UPDATE
app.MapPut("/contacts/{id:int}", (int id, Contact contact, ContactRepository repo) =>
{
    contact.Id = id;
    int rows = repo.Update(contact);

    return rows == 0 ? Results.NotFound() : Results.Ok(contact);
});

// DELETE
app.MapDelete("/contacts/{id:int}", (int id, ContactRepository repo) =>
{
    int rows = repo.Delete(id);
    return rows == 0 ? Results.NotFound() : Results.Ok();
});

app.Run();