using System;

class LibraryManagement
{
    // Arrays to store book data
    static string[] titles = { "C Programming", "Java Basics", "C# Fundamentals", "Data Structures" };
    static string[] authors = { "Dennis Ritchie", "James Gosling", "Microsoft", "Mark Allen Weiss" };
    static bool[] isAvailable = { true, true, true, true };

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n--- Library Management System ---");
            Console.WriteLine("1. Display All Books");
            Console.WriteLine("2. Search Book by Title");
            Console.WriteLine("3. Checkout Book");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayBooks();
                    break;
                case 2:
                    SearchBook();
                    break;
                case 3:
                    CheckoutBook();
                    break;
                case 4:
                    Console.WriteLine("Exiting system...");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        } while (choice != 4);
    }

    // Method to display all books
    static void DisplayBooks()
    {
        Console.WriteLine("\nAvailable Books:");
        for (int i = 0; i < titles.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {titles[i]} by {authors[i]} - " +
                              (isAvailable[i] ? "Available" : "Checked Out"));
        }
    }

    // Method to search book by partial title
    static void SearchBook()
    {
        Console.Write("\nEnter part of the book title to search: ");
        string search = Console.ReadLine().ToLower();
        bool found = false;

        for (int i = 0; i < titles.Length; i++)
        {
            if (titles[i].ToLower().Contains(search))
            {
                Console.WriteLine($"{titles[i]} by {authors[i]} - " +
                                  (isAvailable[i] ? "Available" : "Checked Out"));
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No matching book found.");
        }
    }

    // Method to checkout a book
    static void CheckoutBook()
    {
        Console.Write("\nEnter book number to checkout: ");
        int bookNo = int.Parse(Console.ReadLine()) - 1;

        if (bookNo >= 0 && bookNo < titles.Length)
        {
            if (isAvailable[bookNo])
            {
                isAvailable[bookNo] = false;
                Console.WriteLine("Book checked out successfully.");
            }
            else
            {
                Console.WriteLine("Book is already checked out.");
            }
        }
        else
        {
            Console.WriteLine("Invalid book number.");
        }
    }
}
