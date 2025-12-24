using System;

class ReverseNumberUsingArray
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int count = number.ToString().Length;
        int[] digits = new int[count];

        for (int i = 0; i < count; i++)
        {
            digits[i] = number % 10;
            number /= 10;
        }

        Console.Write("Reversed Number: ");
        foreach (int d in digits)
            Console.Write(d);
    }
}