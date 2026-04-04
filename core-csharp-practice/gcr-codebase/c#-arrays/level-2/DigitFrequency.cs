using System;

class DigitFrequency
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] freq = new int[10];

        while (number != 0)
        {
            int digit = number % 10;
            freq[digit]++;
            number /= 10;
        }

        for (int i = 0; i < 10; i++)
            Console.WriteLine($"Digit {i} = {freq[i]}");
    }
}