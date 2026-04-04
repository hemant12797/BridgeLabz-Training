using System;

public class Movie
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public double Rating { get; set; }

    public Movie(string title, string director, int year, double rating)
    {
        Title = title;
        Director = director;
        Year = year;
        Rating = rating;
    }
}

public class DoublyNode
{
    public Movie Data { get; set; }
    public DoublyNode Prev { get; set; }
    public DoublyNode Next { get; set; }

    public DoublyNode(Movie data)
    {
        Data = data;
        Prev = null;
        Next = null;
    }
}

public class DoublyLinkedList
{
    private DoublyNode head;
    private DoublyNode tail;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
    }

    // Add at beginning
    public void AddAtBeginning(Movie movie)
    {
        DoublyNode newNode = new DoublyNode(movie);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
    }

    // Add at end
    public void AddAtEnd(Movie movie)
    {
        DoublyNode newNode = new DoublyNode(movie);
        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
    }

    // Add at specific position
    public void AddAtPosition(Movie movie, int position)
    {
        if (position < 0)
        {
            Console.WriteLine("Invalid position");
            return;
        }
        if (position == 0)
        {
            AddAtBeginning(movie);
            return;
        }
        DoublyNode newNode = new DoublyNode(movie);
        DoublyNode current = head;
        int count = 0;
        while (current != null && count < position - 1)
        {
            current = current.Next;
            count++;
        }
        if (current == null)
        {
            Console.WriteLine("Position out of range");
            return;
        }
        newNode.Next = current.Next;
        if (current.Next != null)
        {
            current.Next.Prev = newNode;
        }
        else
        {
            tail = newNode;
        }
        current.Next = newNode;
        newNode.Prev = current;
    }

    // Remove by Movie Title
    public void RemoveByTitle(string title)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        DoublyNode current = head;
        while (current != null && current.Data.Title != title)
        {
            current = current.Next;
        }
        if (current == null)
        {
            Console.WriteLine("Movie not found");
            return;
        }
        if (current == head)
        {
            head = head.Next;
            if (head != null)
            {
                head.Prev = null;
            }
            else
            {
                tail = null;
            }
        }
        else if (current == tail)
        {
            tail = tail.Prev;
            tail.Next = null;
        }
        else
        {
            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
        }
    }

    // Search by Director
    public Movie SearchByDirector(string director)
    {
        DoublyNode current = head;
        while (current != null)
        {
            if (current.Data.Director == director)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
    }

    // Search by Rating
    public Movie SearchByRating(double rating)
    {
        DoublyNode current = head;
        while (current != null)
        {
            if (current.Data.Rating == rating)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
    }

    // Display forward
    public void DisplayForward()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        DoublyNode current = head;
        while (current != null)
        {
            Console.WriteLine($"Title: {current.Data.Title}, Director: {current.Data.Director}, Year: {current.Data.Year}, Rating: {current.Data.Rating}");
            current = current.Next;
        }
    }

    // Display reverse
    public void DisplayReverse()
    {
        if (tail == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        DoublyNode current = tail;
        while (current != null)
        {
            Console.WriteLine($"Title: {current.Data.Title}, Director: {current.Data.Director}, Year: {current.Data.Year}, Rating: {current.Data.Rating}");
            current = current.Prev;
        }
    }

    // Update Rating by Title
    public void UpdateRating(string title, double newRating)
    {
        DoublyNode current = head;
        while (current != null)
        {
            if (current.Data.Title == title)
            {
                current.Data.Rating = newRating;
                Console.WriteLine("Rating updated successfully");
                return;
            }
            current = current.Next;
        }
        Console.WriteLine("Movie not found");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DoublyLinkedList list = new DoublyLinkedList();

        // Add some movies
        list.AddAtEnd(new Movie("Inception", "Christopher Nolan", 2010, 8.8));
        list.AddAtEnd(new Movie("The Dark Knight", "Christopher Nolan", 2008, 9.0));
        list.AddAtBeginning(new Movie("Interstellar", "Christopher Nolan", 2014, 8.6));

        Console.WriteLine("Movies forward:");
        list.DisplayForward();

        Console.WriteLine("Movies reverse:");
        list.DisplayReverse();

        // Search
        Movie found = list.SearchByDirector("Christopher Nolan");
        if (found != null)
        {
            Console.WriteLine($"Found: {found.Title}");
        }

        // Update rating
        list.UpdateRating("Inception", 9.0);

        // Remove
        list.RemoveByTitle("Interstellar");

        Console.WriteLine("After operations:");
        list.DisplayForward();
    }
}
