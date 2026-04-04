using System;
using System.Collections;
using System.Collections.Generic;

public class InvalidBookFormatException : Exception
{
    public InvalidBookFormatException(string message) : base(message) { }
}

public class BookBuddy
{
    private ArrayList books;

    public BookBuddy()
    {
        books = new ArrayList();
    }

    public void AddBook(string title, string author)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
        {
            throw new InvalidBookFormatException("Title and author cannot be empty.");
        }
        string bookEntry = $"{title} - {author}";
        books.Add(bookEntry);
    }

    public void SortBooksAlphabetically()
    {
        books.Sort();
    }

    public List<string> SearchByAuthor(string author)
    {
        List<string> results = new List<string>();
        foreach (string book in books)
        {
            string[] parts = book.Split(" - ");
            if (parts.Length == 2 && parts[1].Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                results.Add(book);
            }
        }
        return results;
    }

    public string[] ExportBooks()
    {
        try
        {
            if (books.Count == 0)
            {
                throw new InvalidOperationException("The bookshelf is empty.");
            }
            return (string[])books.ToArray(typeof(string));
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Error: " + e.Message);
            return new string[0];
        }
    }

    public void DisplayBooks()
    {
        try
        {
            if (books.Count == 0)
            {
                throw new InvalidOperationException("The bookshelf is empty.");
            }
            foreach (string book in books)
            {
                Console.WriteLine(book);
            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BookBuddy buddy = new BookBuddy();

        try
        {
            // Add books
            buddy.AddBook("1984", "George Orwell");
            buddy.AddBook("To Kill a Mockingbird", "Harper Lee");
            buddy.AddBook("The Great Gatsby", "F. Scott Fitzgerald");

            // Try invalid book
            buddy.AddBook("", "Author");
        }
        catch (InvalidBookFormatException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        // Sort and display
        buddy.SortBooksAlphabetically();
        Console.WriteLine("Sorted Books:");
        buddy.DisplayBooks();

        // Search by author
        List<string> searchResults = buddy.SearchByAuthor("Harper Lee");
        Console.WriteLine("\nSearch results for 'Harper Lee':");
        foreach (string result in searchResults)
        {
            Console.WriteLine(result);
        }

        // Export
        string[] exported = buddy.ExportBooks();
        Console.WriteLine("\nExported Books:");
        foreach (string book in exported)
        {
            Console.WriteLine(book);
        }
    }
}
