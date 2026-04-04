using System;

class NumberAnalysis
{
    static void Main()
    {
        int[] numbers = new int[5];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine();

        foreach (int num in numbers)
        {
            if (num > 0)
            {
                Console.Write(num + " is positive and ");
                Console.WriteLine(num % 2 == 0 ? "even" : "odd");
            }
            else if (num < 0)
            {
                Console.WriteLine(num + " is negative");
            }
            else
            {
                Console.WriteLine("Number is zero");
            }
        }

        Console.WriteLine();

        if (numbers[0] == numbers[4])
            Console.WriteLine("First and last elements are equal");
        else if (numbers[0] > numbers[4])
            Console.WriteLine("First element is greater than last");
        else
            Console.WriteLine("First element is less than last");
    }
}