using Microsoft.EntityFrameworkCore;
using AdvancedAddressBook.Models;

namespace AdvancedAddressBook.Data
{
    public class AddressBookDbContext : DbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
