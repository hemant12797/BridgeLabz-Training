using System;
class AvgMarksPCM
{
    public static void Main(string[] args)
    {
        int physics = int.Parse(Console.ReadLine());
        int chemistry = int.Parse(Console.ReadLine());
        int maths = int.Parse(Console.ReadLine());
        float avg = (physics+chemistry+maths)/3f;
        Console.WriteLine($"Sam’s average mark in PCM is {avg}");
    }
}