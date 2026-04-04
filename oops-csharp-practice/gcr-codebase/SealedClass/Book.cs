
class Book
{
    public static string LibraryName = "Central Library";

    public string Title;
    public string Author;
    public readonly string ISBN;

    public Book(string title, string author, string isbn)
    {
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
    }

    public static void DisplayLibraryName()
    {
        System.Console.WriteLine(LibraryName);
    }

    public void Display(object obj)
    {
        if (obj is Book)
            System.Console.WriteLine(Title + " " + Author + " " + ISBN);
    }
}
