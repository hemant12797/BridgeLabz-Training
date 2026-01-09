using System;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int BookID { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author, string genre, int bookID, bool isAvailable)
    {
        Title = title;
        Author = author;
        Genre = genre;
        BookID = bookID;
        IsAvailable = isAvailable;
    }
}

public class DoublyNode
{
    public Book Data { get; set; }
    public DoublyNode Prev { get; set; }
    public DoublyNode Next { get; set; }

    public DoublyNode(Book data)
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
    public void AddAtBeginning(Book book)
    {
        DoublyNode newNode = new DoublyNode(book);
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
    public void AddAtEnd(Book book)
    {
        DoublyNode newNode = new DoublyNode(book);
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
    public void AddAtPosition(Book book, int position)
    {
        if (position < 0)
        {
            Console.WriteLine("Invalid position");
            return;
        }
        if (position == 0)
        {
            AddAtBeginning(book);
            return;
        }
        DoublyNode newNode = new DoublyNode(book);
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

    // Remove by Book ID
    public void RemoveByBookID(int bookID)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        DoublyNode current = head;
        while (current != null && current.Data.BookID != bookID)
        {
            current = current.Next;
        }
        if (current == null)
        {
            Console.WriteLine("Book not found");
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

    // Search by Book Title
    public Book SearchByTitle(string title)
    {
        DoublyNode current = head;
        while (current != null)
        {
            if (current.Data.Title == title)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
    }

    // Search by Author
    public Book SearchByAuthor(string author)
    {
        DoublyNode current = head;
        while (current != null)
        {
            if (current.Data.Author == author)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
    }

    // Update Availability Status
    public void UpdateAvailability(int bookID, bool isAvailable)
    {
        DoublyNode current = head;
        while (current != null)
        {
            if (current.Data.BookID == bookID)
            {
                current.Data.IsAvailable = isAvailable;
                Console.WriteLine("Availability updated successfully");
                return;
            }
            current = current.Next;
        }
        Console.WriteLine("Book not found");
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
            Console.WriteLine($"Book ID: {current.Data.BookID}, Title: {current.Data.Title}, Author: {current.Data.Author}, Genre: {current.Data.Genre}, Available: {current.Data.IsAvailable}");
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
            Console.WriteLine($"Book ID: {current.Data.BookID}, Title: {current.Data.Title}, Author: {current.Data.Author}, Genre: {current.Data.Genre}, Available: {current.Data.IsAvailable}");
            current = current.Prev;
        }
    }

    // Count total books
    public int CountBooks()
    {
        int count = 0;
        DoublyNode current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DoublyLinkedList list = new DoublyLinkedList();

        // Add some books
        list.AddAtEnd(new Book("1984", "George Orwell", "Dystopian", 1, true));
        list.AddAtEnd(new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", 2, false));
        list.AddAtBeginning(new Book("Pride and Prejudice", "Jane Austen", "Romance", 0, true));

        Console.WriteLine("Books forward:");
        list.DisplayForward();

        Console.WriteLine("Books reverse:");
        list.DisplayReverse();

        // Search
        Book found = list.SearchByAuthor("George Orwell");
        if (found != null)
        {
            Console.WriteLine($"Found: {found.Title}");
        }

        // Update availability
        list.UpdateAvailability(2, true);

        // Count
        Console.WriteLine($"Total books: {list.CountBooks()}");

        // Remove
        list.RemoveByBookID(0);

        Console.WriteLine("After operations:");
        list.DisplayForward();
    }
}
