
class Book
{
    public string Title;
    public int PublicationYear;

    public virtual void DisplayInfo()
    {
        System.Console.WriteLine(Title + " " + PublicationYear);
    }
}

class Author : Book
{
    public string Name;
    public string Bio;

    public override void DisplayInfo()
    {
        System.Console.WriteLine(Title + " " + PublicationYear + " " + Name + " " + Bio);
    }
}
