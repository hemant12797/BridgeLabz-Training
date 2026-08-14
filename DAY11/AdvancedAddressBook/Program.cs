using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AdvancedAddressBook.Data;
using AdvancedAddressBook.Repositories;
using AdvancedAddressBook.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure EF Core with SQL Server
builder.Services.AddDbContext<AddressBookDbContext>(options =>
    options.UseSqlServer("Server=.\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;TrustServerCertificate=True;"));

// Register dependencies
builder.Services.AddScoped<AddressBookRepository>();
builder.Services.AddScoped<AddressBookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
