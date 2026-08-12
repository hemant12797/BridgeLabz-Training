using Microsoft.EntityFrameworkCore;
using ContactsApiEF.Models;

namespace ContactsApiEF.DataLayer;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts => Set<Contact>();
}