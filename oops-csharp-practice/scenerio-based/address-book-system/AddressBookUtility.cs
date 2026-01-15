using System.Resources;
using System.Runtime.Loader;

internal class AddressBookUtility : IAddressBook
{
    private AddressBook[] AddressBooks;
    private int AddressBookArrayIndex;

    public AddressBookUtility()
    {
        AddressBooks = AddressBookMain.AddressBooks;
        AddressBookArrayIndex = AddressBookMain.AddressBookArrayIndex;
    }
    public void AddContact()
    {
        Console.WriteLine("\n==== Contact Adding Window ====\n");
        Console.Write("Enter address book name (press enter for default): ");
        string addressBookName = Console.ReadLine();

        if (addressBookName == "") addressBookName = "default";

        AddressBook addressBook = FindAddressBookByName(addressBookName);

        if (addressBook == null)
        {
            Console.WriteLine("\nAddress book with this name doesn't exist.\n");
            return;
        }

        int addressBookIndex = addressBook.GetCurrentIndex();
        int addressBookMaxSize = addressBook.GetMaxSize();
        Contact[] contacts = addressBook.GetContacts();

        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();

        if (IsDuplicate(firstName, addressBookName))
        {
            Console.WriteLine("\nA contact with same first name already exist.\n");
            return;
        }

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter city name: ");
        string city = Console.ReadLine();
        Console.Write("Enter state name: ");
        string state = Console.ReadLine();
        Console.Write("Enter Zip code: ");
        string zipCode = Console.ReadLine();
        Console.Write("Enter Phone number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Contact newContact = new Contact(firstName, lastName, city, state, zipCode, phoneNumber, email);

        if (addressBookIndex < addressBookMaxSize)
        {
            // Updating Contacts array here also updates the Contacts array in the state as this is reference type
            contacts[addressBookIndex++] = newContact;
            // Since AddressBookIndex is int, to update the state, we'll have to call the setter method
            addressBook.SetCurrentIndex(addressBookIndex);
            Console.WriteLine("\nContact added successfully.\n");
        }
        else
        {
            Console.WriteLine("\nContact array is full.\n");
        }
    }

    // Helper method for AddContact
    // Returns Address book if found
    // Returns null otherwise
    private AddressBook FindAddressBookByName(string addressBookName)
    {
        for (int i = 0; i < AddressBookArrayIndex; i++)
        {
            if (AddressBooks[i].GetAddressBookName().Equals(addressBookName))
            {
                return AddressBooks[i];
            }
        }

        return null;
    }

    // Checks if a contact with the same first name alread exists
    // If exists, return true
    // Else returns false;
    private bool IsDuplicate(string firstName, string addressBookName)
    {
        AddressBook addressBook = FindAddressBookByName(addressBookName);

        for (int i = 0; i < addressBook.GetCurrentIndex(); i++)
        {
            if (addressBook.GetContacts()[i].GetFirstName().Equals(firstName))
            {
                return true;
            }
        }
        return false;
    }

    public void DisplayAllContacts()
    {
        Console.WriteLine("\nHere are all the contacts across all the address books\n");
        for (int i = 0; i < AddressBookArrayIndex; i++)
        {
            AddressBook addressBook = AddressBooks[i];
            Console.WriteLine($"\nBook Name: {addressBook.GetAddressBookName()}");
            for (int j = 0; j < addressBook.GetCurrentIndex(); j++)
            {
                Console.WriteLine(addressBook.GetContacts()[j]);
            }
        }
        Console.WriteLine("\n");
    }

    public void EditExistingContact()
    {
        Console.WriteLine("\n==== Editing Existing Contact Window ====\n");
        Console.Write("Enter contact first name: ");
        string firstName = Console.ReadLine();
        Contact contact = FindContactByName(firstName);

        if (contact == null)
        {
            Console.WriteLine("\nContact with this first name doesn't exist\n");
            return;
        }

        Console.WriteLine("1. Edit first name.");
        Console.WriteLine("2. Edit last name.");
        Console.WriteLine("3. Edit city name.");
        Console.WriteLine("4. Edit state name.");
        Console.WriteLine("5. Edit zip code.");
        Console.WriteLine("6. Edit phone number.");
        Console.WriteLine("7. Edit Email.");
        Console.WriteLine("0. Cancel Edit");
        Console.Write("\nPlease enter your choice: ");
        int choice = int.Parse(Console.ReadLine());
        Console.WriteLine("\n");

        switch (choice)
        {
            case 1:
                Console.Write("Please enter updated first name: ");
                string updatedFirstName = Console.ReadLine();
                contact.SetFirstName(updatedFirstName);
                break;
            case 2:
                Console.Write("Please enter updated last name: ");
                string lastName = Console.ReadLine();
                contact.SetLastName(lastName);
                break;
            case 3:
                Console.Write("Please enter updated city name: ");
                string cityName = Console.ReadLine();
                contact.SetCity(cityName);
                break;
            case 4:
                Console.Write("Please enter updated state name: ");
                string stateName = Console.ReadLine();
                contact.SetState(stateName);
                break;
            case 5:
                Console.Write("Please enter updated zip code: ");
                string zipCode = Console.ReadLine();
                contact.SetZipCode(zipCode);
                break;
            case 6:
                Console.Write("Please enter updated phone number: ");
                string phoneNumber = Console.ReadLine();
                contact.SetPhoneNumber(phoneNumber);
                break;
            case 7:
                Console.Write("Please enter updated email: ");
                string email = Console.ReadLine();
                contact.SetEmail(email);
                break;
            case 0:
                return;
        }

        Console.WriteLine("\nContact Updated Successfully...\n");
    }

    // Helper method for EditExistingContact method to find a contact across all the books given its firstName
    // Returns the contact if the contact is found in the array
    // Returns null otherwise
    private Contact FindContactByName(string firstName)
    {
        for (int i = 0; i < AddressBookArrayIndex; i++)
        {
            for (int j = 0; j < AddressBooks[i].GetCurrentIndex(); j++)
            {
                Console.WriteLine();
                if (AddressBooks[i].GetContacts()[j].GetFirstName().Equals(firstName))
                {
                    return AddressBooks[i].GetContacts()[j];
                }
            }
        }

        return null;
    }

    public void DeleteContact()
    {
        Console.WriteLine("\n==== Contact Deletion Windows ====\n");
        Console.Write("Please enter the first name of the contact to delete: ");
        string firstName = Console.ReadLine();
        int contactIndex = FindContactIndex(firstName);

        if (contactIndex == -1)
        {
            Console.WriteLine("\nContact with this first name doesn't exist\n");
            return;
        }

        /*
         Contact Deletion Logic:
            We'll start from the contact index and copy the next cells value in the current cell
            At the End, decrement AddressBookIndex by 1 to reflect deletion
            This way we'll preserve all the contacts and delete the given one
         */

        AddressBook addressBook = FindAddressBookByContactName(firstName);

        for (int i = contactIndex; i < addressBook.GetCurrentIndex() && i < addressBook.GetMaxSize() - 1; i++)
        {
            addressBook.GetContacts()[i] = addressBook.GetContacts()[i + 1];
        }

        addressBook.SetCurrentIndex(addressBook.GetCurrentIndex() - 1);

        Console.WriteLine("\nContact Deleted Successfully...\n");
    }

    // Helper method for DeleteContact method to find the index of a contact given its first name
    // Returns the contact index if the contact is found in the array
    // Return -1 otherwise
    private int FindContactIndex(string firstName)
    {
        for (int i = 0; i < AddressBookArrayIndex; i++)
        {
            for (int j = 0; j < AddressBooks[i].GetCurrentIndex(); j++)
            {
                Console.WriteLine();
                if (AddressBooks[i].GetContacts()[j].GetFirstName().Equals(firstName))
                {
                    return j;
                }
            }
        }

        return -1;
    }

    private AddressBook FindAddressBookByContactName(string firstName)
    {
        for (int i = 0; i < AddressBookArrayIndex; i++)
        {
            for (int j = 0; j < AddressBooks[i].GetCurrentIndex(); j++)
            {
                Console.WriteLine();
                if (AddressBooks[i].GetContacts()[j].GetFirstName().Equals(firstName))
                {
                    return AddressBooks[i];
                }
            }
        }

        return null;
    }

    public void AddMultipleContacts()
    {
        Console.Write("\nPlease enter address book name: ");
        string bookName = Console.ReadLine();

        AddressBook addressBook = FindAddressBookByName(bookName);

        if (addressBook == null)
        {
            Console.WriteLine("\nAddress book with given name doesn't exist.\n");
            return;
        }

        int remainingSpace = addressBook.GetMaxSize() - addressBook.GetCurrentIndex();
        Console.WriteLine($"\nYou can add at most {remainingSpace}\n");
        Console.Write("Please enter the number of contacts to you want to add: ");
        int numberOfContacts = int.Parse(Console.ReadLine());
        if (numberOfContacts > (remainingSpace))
        {
            Console.WriteLine($"Please enter a number <= {remainingSpace}. Try again");
            return;
        }
        for (int i = 0; i < numberOfContacts; i++)
        {
            AddContact();
        }
    }

    public void ListAllAddressBooks()
    {
        Console.WriteLine("\nHere is a list of all the address books: \n");
        for (int i = 0; i < AddressBookArrayIndex; i++)
        {
            Console.WriteLine($"Address Book Name: {AddressBooks[i].GetAddressBookName()}");
        }
    }

    public void CreateAddressBook()
    {
        if (AddressBookArrayIndex >= AddressBooks.Length)
        {
            Console.WriteLine("\nAddress book array is already full. You cannot create any more address books.\n");
            return;
        }

        Console.WriteLine("\n==== Address Book Creation Window ====\n");
        Console.Write("Please enter address book max capacity: ");
        int addressBookMaxCapacity = int.Parse(Console.ReadLine());
        Console.Write("Please enter address book name: ");
        string addressBookName = Console.ReadLine();

        AddressBook NewAddressBook = new AddressBook(addressBookMaxCapacity, addressBookName);

        AddressBooks[AddressBookArrayIndex++] = NewAddressBook;
    }
    
    public void ListAllContactsInCityOrState()
    {
        Console.WriteLine("\n==== List all contacts in a city or state ====\n");
        Console.Write("Please enter city or state: ");
        string searchQuery = Console.ReadLine();
        Console.WriteLine($"\nHere are all the contacts that reside in {searchQuery}:\n");

        // Looking for cities or states which are equal to searchQuery and displaying all such contacts
        for (int i = 0; i < AddressBookArrayIndex; i++)
        {
            for(int j = 0; j < AddressBooks[i].GetCurrentIndex(); j++)
            {
                if (AddressBooks[i].GetContacts()[j].GetCity().Equals(searchQuery) || AddressBooks[i].GetContacts()[j].GetState().Equals(searchQuery))
                {
                    Console.WriteLine(AddressBooks[i].GetContacts()[j]);
                }
            }
        }

        Console.WriteLine("\n");
    }

    public void SearchContactInCityOrState()
    {
        Console.WriteLine("\n==== Search a contact in a city or state ====\n");
        Console.Write("Enter Contact's first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter Contact's city or state name: ");
        string cityOrStateName = Console.ReadLine();
        Console.WriteLine("\nHere is the result: \n");

        // Looking for the given contact in the given city or state
        for (int i = 0; i < AddressBookArrayIndex; i++)
        {
            for (int j = 0; j < AddressBooks[i].GetCurrentIndex(); j++)
            {
                if (AddressBooks[i].GetContacts()[j].GetFirstName().Equals(firstName) && (AddressBooks[i].GetContacts()[j].GetCity().Equals(cityOrStateName) || AddressBooks[i].GetContacts()[j].GetState().Equals(cityOrStateName)))
                {
                    Console.WriteLine(AddressBooks[i].GetContacts()[j]);
                }
            }
        }
    }

    public void CountContactsByCityOrState()
    {
        Console.WriteLine("\n==== Count Contacts By City or State name ====\n");
        Console.Write("Please enter the city or state name: ");
        string searchQuery = Console.ReadLine();
        int contactsCount = 0;

        for (int i = 0; i < AddressBookArrayIndex; i++)
        {
            for (int j = 0; j < AddressBooks[i].GetCurrentIndex(); j++)
            {
                if (AddressBooks[i].GetContacts()[j].GetCity().Equals(searchQuery) || AddressBooks[i].GetContacts()[j].GetState().Equals(searchQuery))
                {
                    contactsCount++;
                }
            }
        }

        Console.WriteLine($"\nThe number of contacts residing in {searchQuery} is: {contactsCount}\n");
    }

    public void SortContactsAlphabeticallyByFirstName()
    {
        Console.WriteLine("\n==== Result of sorting contacts.");
        for(int i = 0; i < AddressBookArrayIndex; i++)
        {
            QuickSort(AddressBooks[i].GetContacts(), 0, AddressBooks[i].GetCurrentIndex() - 1);
        }
        DisplayAllContacts();
    }

    private void QuickSort(Contact[] contacts, int left, int right)
    {
        if(left >= right)
        {
            return;
        }

        int pivotIndex = Partition(contacts, left, right);

        QuickSort(contacts, left, pivotIndex - 1);
        QuickSort(contacts, pivotIndex + 1, right);
    }

    private int Partition(Contact[] contacts, int left, int right)
    {
        Contact pivot = contacts[right];
        int boundary = left - 1;

        for(int i = left; i <= right-1; i++)
        {
            if (String.Compare(contacts[i].GetFirstName(), pivot.GetFirstName()) < 0)
            {
                boundary++;
                // Swapping
                Contact temp = contacts[i];
                contacts[i] = contacts[boundary];
                contacts[boundary] = temp;
            }
        }
        contacts[right] = contacts[boundary + 1];
        contacts[boundary + 1] = pivot;

        return boundary + 1;
    }
}