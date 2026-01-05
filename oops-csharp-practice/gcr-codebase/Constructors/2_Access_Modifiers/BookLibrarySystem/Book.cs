
class Book
{
    public string ISBN;
    protected string title;
    private string author;

    public void SetAuthor(string a)
    {
        author = a;
    }

    public string GetAuthor()
    {
        return author;
    }
}

class EBook : Book
{
    public void ShowDetails()
    {
        System.Console.WriteLine(ISBN + " " + title);
    }
}
