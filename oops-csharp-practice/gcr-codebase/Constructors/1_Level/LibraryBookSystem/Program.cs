using System;

class Program
{
    static void Main()
    {
        LibraryBook lb = new LibraryBook("C# Guide", "Ashish", 300);
        lb.BorrowBook();
        lb.BorrowBook();
    }
}
