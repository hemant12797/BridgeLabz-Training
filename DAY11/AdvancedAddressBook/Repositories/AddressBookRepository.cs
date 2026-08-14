using System.Collections.Generic;
using System.Linq;
using AdvancedAddressBook.Models;
using AdvancedAddressBook.Data;

namespace AdvancedAddressBook.Repositories
{
    public class AddressBookRepository
    {
        private readonly AddressBookDbContext _context;

        public AddressBookRepository(AddressBookDbContext context)
        {
            _context = context;
        }

        public void InsertContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public List<Contact> GetAllContacts()
        {
            return _context.Contacts.ToList();
        }

        public void DeleteContact(string firstName)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.FirstName == firstName);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }
    }
}
