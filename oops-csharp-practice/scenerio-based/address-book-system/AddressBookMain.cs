internal class AddressBookMain
{
    // Now we support adding multiple address books
    public static AddressBook[] AddressBooks;
    public static int AddressBookArrayIndex;

    static AddressBookMain()
    {
        // The user can add at most 10 address books.
        AddressBooks = new AddressBook[10]; 
        // Initially we add an address book with a max size of 10 and name default.
        AddressBooks[0] = new AddressBook(10, "default");
        AddressBookArrayIndex = 1; // As index 0 is occupied by address book named "default"
    }
    static void Main(string[] args)
    {
        AddressBookMenu addressBookMenu = new AddressBookMenu();
        addressBookMenu.ShowMenu();
    }
}