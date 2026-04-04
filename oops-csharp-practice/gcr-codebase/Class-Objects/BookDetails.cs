using System;

class BookDetails
{
    private string title;
    private string author;
    private double price;

    public BookDetails(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public void DisplayBookDetails()
    {
        Console.WriteLine("\n========= Book Details =========");
        Console.WriteLine($"Title  : {title}");
        Console.WriteLine($"Author : {author}");
        Console.WriteLine($"Price  : {price}");
    }
}
