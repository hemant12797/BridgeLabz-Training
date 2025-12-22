using System;

public class DivisibleBy5
{
    public static void Main(String[] args)
    {
        Console.Write("Enter the number: ");
        int num = int.Parse(Console.ReadLine());

        if(num % 5 == 0)
        {
            Console.WriteLine("Is the number "+ num +" divisible by 5? true");
        }
        else
        {
            Console.WriteLine("Is the number "+ num +" divisible by 5? false");
        }
    }
}