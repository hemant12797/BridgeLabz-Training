using System.Collections.Generic;
using System.Linq;
using AdvancedAddressBook.Models;
using AdvancedAddressBook.Repositories;

namespace AdvancedAddressBook.Services
{
    public class AddressBookService
    {
        private readonly AddressBookRepository _repository;

        public AddressBookService(AddressBookRepository repo)
        {
            _repository = repo;
        }

        public void AddContact(Contact contact)
        {
            if (string.IsNullOrEmpty(contact.FirstName))
                throw new System.Exception("First Name cannot be empty");

            _repository.InsertContact(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _repository.GetAllContacts();
        }

        public Contact SearchContact(string firstName)
        {
            return _repository.GetAllContacts().FirstOrDefault(c => c.FirstName == firstName);
        }

        public void DeleteContact(string firstName)
        {
            _repository.DeleteContact(firstName);
        }
    }
}
