using System;

class TableSixToNine
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] result = new int[4];

        for (int i = 6; i <= 9; i++)
        {
            result[i - 6] = number * i;
            Console.WriteLine($"{number} * {i} = {result[i - 6]}");
        }
    }
}