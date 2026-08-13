using System;
using System.Collections.Generic;
using AdvancedAddressBook.Models;
using AdvancedAddressBook.Repositories;
using AdvancedAddressBook.Services;

namespace AdvancedAddressBook
{
    class Program
    {
        static AddressBookService? service;

        static void Main(string[] args)
        {
            try
            {
                service = new AddressBookService(new AddressBookRepository());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection failed:");
                Console.WriteLine(ex.Message);
                return;
            }

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===== ADDRESS BOOK MENU =====");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View All Contacts");
                Console.WriteLine("3. Edit Existing Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Add Multiple Contacts");
                Console.WriteLine("6. List all Address Books");
                Console.WriteLine("7. Create an Address Book");
                Console.WriteLine("8. List contacts by City or State");
                Console.WriteLine("9. Search by Name and City/State");
                Console.WriteLine("10. Count contacts by City or State");
                Console.WriteLine("11. View Sorted Contacts (A-Z)");
                Console.WriteLine("12. Exit");
                Console.Write("Select Option: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddContact();
                            break;
                        case 2:
                            ViewContacts();
                            break;
                        case 3:
                            EditContact();
                            break;
                        case 4:
                            DeleteContact();
                            break;
                        case 5:
                            AddMultipleContacts();
                            break;
                        case 6:
                            ListAddressBooks();
                            break;
                        case 7:
                            CreateAddressBook();
                            break;
                        case 8:
                            ListContactsByCityOrState();
                            break;
                        case 9:
                            SearchByNameAndCityOrState();
                            break;
                        case 10:
                            CountContactsByCityOrState();
                            break;
                        case 11:
                            ViewSortedContacts();
                            break;
                        case 12:
                            exit = true;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void AddContact()
        {
            Contact contact = new Contact();

            Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("City: ");
            contact.City = Console.ReadLine();

            Console.Write("State: ");
            contact.State = Console.ReadLine();

            Console.Write("Zip Code: ");
            contact.ZipCode = Console.ReadLine();

            Console.Write("Phone: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("Email: ");
            contact.Email = Console.ReadLine();

            Console.Write("Address Book ID (press Enter for default): ");
            string addressBookIdStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(addressBookIdStr))
            {
                contact.AddressBookId = Convert.ToInt32(addressBookIdStr);
            }

            service.AddContact(contact);
            Console.WriteLine("Contact Added Successfully!");
        }

        static void ViewContacts()
        {
            var contacts = service.GetAllContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        static void EditContact()
        {
            Console.Write("Enter First Name of contact to edit: ");
            string firstName = Console.ReadLine();

            var contact = service.SearchContact(firstName);
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("Current contact details:");
            Console.WriteLine(contact);

            Console.WriteLine("\nEnter new details (press Enter to keep current value):");

            Console.Write($"First Name [{contact.FirstName}]: ");
            string firstNameInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(firstNameInput))
                contact.FirstName = firstNameInput;

            Console.Write($"Last Name [{contact.LastName}]: ");
            string lastNameInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(lastNameInput))
                contact.LastName = lastNameInput;

            Console.Write($"Address [{contact.Address}]: ");
            string addressInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(addressInput))
                contact.Address = addressInput;

            Console.Write($"City [{contact.City}]: ");
            string cityInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(cityInput))
                contact.City = cityInput;

            Console.Write($"State [{contact.State}]: ");
            string stateInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(stateInput))
                contact.State = stateInput;

            Console.Write($"Zip Code [{contact.ZipCode}]: ");
            string zipInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(zipInput))
                contact.ZipCode = zipInput;

            Console.Write($"Phone [{contact.PhoneNumber}]: ");
            string phoneInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(phoneInput))
                contact.PhoneNumber = phoneInput;

            Console.Write($"Email [{contact.Email}]: ");
            string emailInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(emailInput))
                contact.Email = emailInput;

            service.UpdateContact(contact);
            Console.WriteLine("Contact Updated Successfully!");
        }

        static void DeleteContact()
        {
            Console.Write("Enter First Name to Delete: ");
            string name = Console.ReadLine();

            service.DeleteContact(name);
            Console.WriteLine("Contact Deleted (if existed).");
        }

        static void AddMultipleContacts()
        {
            Console.Write("How many contacts do you want to add? ");
            int count = Convert.ToInt32(Console.ReadLine());

            List<Contact> contacts = new List<Contact>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n--- Contact {i + 1} ---");
                Contact contact = new Contact();

                Console.Write("First Name: ");
                contact.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                contact.LastName = Console.ReadLine();

                Console.Write("Address: ");
                contact.Address = Console.ReadLine();

                Console.Write("City: ");
                contact.City = Console.ReadLine();

                Console.Write("State: ");
                contact.State = Console.ReadLine();

                Console.Write("Zip Code: ");
                contact.ZipCode = Console.ReadLine();

                Console.Write("Phone: ");
                contact.PhoneNumber = Console.ReadLine();

                Console.Write("Email: ");
                contact.Email = Console.ReadLine();

                Console.Write("Address Book ID (press Enter for default): ");
                string addressBookIdStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(addressBookIdStr))
                {
                    contact.AddressBookId = Convert.ToInt32(addressBookIdStr);
                }

                contacts.Add(contact);
            }

            service.AddMultipleContacts(contacts);
            Console.WriteLine($"{count} Contacts Added Successfully!");
        }

        static void ListAddressBooks()
        {
            var addressBooks = service.GetAllAddressBooks();
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No Address Books found.");
                return;
            }

            Console.WriteLine("\n===== Address Books =====");
            foreach (var ab in addressBooks)
            {
                Console.WriteLine($"ID: {ab["AddressBookId"]}, Name: {ab["AddressBookName"]}, Created: {ab["CreatedDate"]}");
            }
        }

        static void CreateAddressBook()
        {
            Console.Write("Enter Address Book Name: ");
            string name = Console.ReadLine();

            service.CreateAddressBook(name);
            Console.WriteLine("Address Book Created Successfully!");
        }

        static void ListContactsByCityOrState()
        {
            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            var contacts = service.GetContactsByCityOrState(city, state);
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found in that city or state.");
                return;
            }

            Console.WriteLine($"\n===== Contacts in {city} / {state} =====");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        static void SearchByNameAndCityOrState()
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            var contacts = service.SearchContactByNameAndCityOrState(firstName, city, state);
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found matching criteria.");
                return;
            }

            Console.WriteLine($"\n===== Search Results =====");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        static void CountContactsByCityOrState()
        {
            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            int count = service.CountContactsByCityOrState(city, state);
            Console.WriteLine($"\nTotal contacts in {city} / {state}: {count}");
        }

        static void ViewSortedContacts()
        {
            var contacts = service.GetAllContactsSorted();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            Console.WriteLine("\n===== Contacts (Sorted A-Z) =====");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}
