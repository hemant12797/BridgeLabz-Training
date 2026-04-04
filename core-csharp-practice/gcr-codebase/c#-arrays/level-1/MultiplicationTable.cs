using System;

class MultiplicationTable
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] table = new int[10];

        for (int i = 1; i <= 10; i++)
        {
            table[i - 1] = number * i;
            Console.WriteLine($"{number} * {i} = {table[i - 1]}");
        }
    }
}