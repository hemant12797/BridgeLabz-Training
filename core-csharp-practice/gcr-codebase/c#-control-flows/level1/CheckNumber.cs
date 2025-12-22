using System;

public class CheckNumber
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the number: ");
        int num = int.Parse(Console.ReadLine());
        
        if(num > 0)
        {
            Console.WriteLine("positive");
        }
        else if(num < 0)
        {
            Console.WriteLine("negative");
        }
        else
        {
            Console.WriteLine("zero");
        }

    }
}