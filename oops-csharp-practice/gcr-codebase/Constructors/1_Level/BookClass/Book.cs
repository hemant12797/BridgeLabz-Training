class Book
{
    public string Title;
    public string Author;
    public double Price;

    public Book()
    {
        Title = "Unknown";
        Author = "Unknown";
        Price = 0;
    }

    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }
}
