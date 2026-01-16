using System;

namespace BookShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool running = true;

            Console.WriteLine("Welcome to BookShelf - Library Organizer");

            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Remove a book");
                Console.WriteLine("3. List books by genre");
                Console.WriteLine("4. List all genres");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter book title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter genre: ");
                        string genre = Console.ReadLine();
                        library.AddBook(title, author, genre);
                        break;
                    case "2":
                        Console.Write("Enter book title to remove: ");
                        string removeTitle = Console.ReadLine();
                        library.RemoveBook(removeTitle);
                        break;
                    case "3":
                        Console.Write("Enter genre: ");
                        string listGenre = Console.ReadLine();
                        library.ListBooksByGenre(listGenre);
                        break;
                    case "4":
                        library.ListAllGenres();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for using BookShelf!");
        }
    }
}
