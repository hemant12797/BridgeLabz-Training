using System;

public class FindAge
{
    public static void Main(String[] args)
    {
        int birthyear = 2000;
        int currentyear = 2024;

        int age = currentyear - birthyear;

        Console.WriteLine("Harry's age in 2024 is "+ (age));
    }
}