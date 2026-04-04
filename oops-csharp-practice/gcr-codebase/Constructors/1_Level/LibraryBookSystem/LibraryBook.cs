class LibraryBook
{
    public string Title;
    public string Author;
    public double Price;
    public bool Available;

    public LibraryBook(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
        Available = true;
    }

    public void BorrowBook()
    {
        if (Available)
        {
            Available = false;
            System.Console.WriteLine("Book borrowed successfully");
        }
        else
        {
            System.Console.WriteLine("Book not available");
        }
    }
}
