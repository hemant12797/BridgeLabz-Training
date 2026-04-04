
using System.Collections.Generic;

class Book
{
    public string Title;
    public string Author;

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}

class Library
{
    public List<Book> Books = new List<Book>();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }
}
