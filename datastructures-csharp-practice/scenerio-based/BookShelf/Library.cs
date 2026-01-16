using System;
using System.Collections.Generic;

namespace BookShelf
{
    public class Library
    {
        private Dictionary<string, LinkedList<Book>> genreCatalog;
        private HashSet<Book> bookSet;

        public Library()
        {
            genreCatalog = new Dictionary<string, LinkedList<Book>>();
            bookSet = new HashSet<Book>();
        }

        public void AddBook(string title, string author, string genre)
        {
            Book newBook = new Book(title, author, genre);
            if (bookSet.Contains(newBook))
            {
                Console.WriteLine("Book already exists in the library.");
                return;
            }

            if (!genreCatalog.ContainsKey(genre))
            {
                genreCatalog[genre] = new LinkedList<Book>();
            }

            genreCatalog[genre].AddLast(newBook);
            bookSet.Add(newBook);
            Console.WriteLine($"Book '{title}' added to genre '{genre}'.");
        }

        public void RemoveBook(string title)
        {
            foreach (var genre in genreCatalog.Keys)
            {
                var books = genreCatalog[genre];
                for (var node = books.First; node != null; node = node.Next)
                {
                    if (node.Value.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        books.Remove(node);
                        bookSet.Remove(node.Value);
                        Console.WriteLine($"Book '{title}' removed from genre '{genre}'.");
                        return;
                    }
                }
            }
            Console.WriteLine($"Book '{title}' not found in the library.");
        }

        public void ListBooksByGenre(string genre)
        {
            if (genreCatalog.ContainsKey(genre))
            {
                Console.WriteLine($"Books in genre '{genre}':");
                foreach (var book in genreCatalog[genre])
                {
                    Console.WriteLine($"- {book}");
                }
            }
            else
            {
                Console.WriteLine($"No books found in genre '{genre}'.");
            }
        }

        public void ListAllGenres()
        {
            Console.WriteLine("Available genres:");
            foreach (var genre in genreCatalog.Keys)
            {
                Console.WriteLine($"- {genre}");
            }
        }
    }
}
