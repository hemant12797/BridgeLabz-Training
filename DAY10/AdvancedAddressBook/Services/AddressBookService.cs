using System.Collections.Generic;
using System.Linq;
using AdvancedAddressBook.Models;
using AdvancedAddressBook.Repositories;

namespace AdvancedAddressBook.Services
{
    public class AddressBookService
    {
        private AddressBookRepository repository;
        private List<Contact> contacts = new List<Contact>();

        public AddressBookService(AddressBookRepository repo)
        {
            repository = repo;
            // Initialize database first (creates DB and tables if they don't exist)
            repository.InitializeDatabase();
            contacts = repository.GetAllContacts();
        }

        public void AddContact(Contact contact)
        {
            if (string.IsNullOrEmpty(contact.FirstName))
                throw new System.Exception("First Name cannot be empty");

            // Default to AddressBookId 1 if not specified
            if (contact.AddressBookId == 0)
                contact.AddressBookId = 1;

            repository.InsertContact(contact);
            contacts = repository.GetAllContacts();
        }

        // Add multiple contacts
        public void AddMultipleContacts(List<Contact> contactList)
        {
            foreach (var contact in contactList)
            {
                if (string.IsNullOrEmpty(contact.FirstName))
                    throw new System.Exception("First Name cannot be empty");
                
                // Default to AddressBookId 1 if not specified
                if (contact.AddressBookId == 0)
                    contact.AddressBookId = 1;
            }

            foreach (var contact in contactList)
            {
                repository.InsertContact(contact);
            }
            contacts = repository.GetAllContacts();
        }

        public List<Contact> GetAllContacts()
        {
            return repository.GetAllContacts();
        }

        // Get all contacts sorted alphabetically by first name
        public List<Contact> GetAllContactsSorted()
        {
            var sortedContacts = repository.GetAllContacts();
            return sortedContacts.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();
        }

        public Contact SearchContact(string firstName)
        {
            return repository.GetAllContacts().FirstOrDefault(c => c.FirstName == firstName);
        }

        // Search contact by first name and city or state
        public List<Contact> SearchContactByNameAndCityOrState(string firstName, string city, string state)
        {
            return repository.SearchContactByNameAndCityOrState(firstName, city, state);
        }

        public void DeleteContact(string firstName)
        {
            repository.DeleteContact(firstName);
            contacts = repository.GetAllContacts();
        }

        // Edit existing contact
        public void UpdateContact(Contact contact)
        {
            if (string.IsNullOrEmpty(contact.FirstName))
                throw new System.Exception("First Name cannot be empty");

            repository.UpdateContact(contact);
            contacts = repository.GetAllContacts();
        }

        // Create a new Address Book
        public void CreateAddressBook(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new System.Exception("Address Book Name cannot be empty");

            repository.CreateAddressBook(name);
        }

        // List all Address Books
        public List<Dictionary<string, object>> GetAllAddressBooks()
        {
            return repository.GetAllAddressBooks();
        }

        // List all contacts in a city or state
        public List<Contact> GetContactsByCityOrState(string city, string state)
        {
            return repository.GetContactsByCityOrState(city, state);
        }

        // Count contacts in a city or state
        public int CountContactsByCityOrState(string city, string state)
        {
            return repository.CountContactsByCityOrState(city, state);
        }

        // Get contact by ID
        public Contact GetContactById(int contactId)
        {
            return repository.GetContactById(contactId);
        }
    }
}
