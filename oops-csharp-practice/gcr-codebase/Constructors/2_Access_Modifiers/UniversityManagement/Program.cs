
using System;
class Program
{
    static void Main()
    {
        PostgraduateStudent s = new PostgraduateStudent();
        s.rollNumber = 1;
        s.SetCGPA(8.5);
        Console.WriteLine(s.GetCGPA());
    }
}
