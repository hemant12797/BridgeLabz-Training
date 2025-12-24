using System;

class ArraySum
{
    static void Main()
    {
        double[] values = new double[10];
        double total = 0.0;
        int index = 0;

        while (true)
        {
            Console.Write("Enter a number: ");
            double input = Convert.ToDouble(Console.ReadLine());

            if (input <= 0 || index == values.Length)
                break;

            values[index++] = input;
        }

        for (int i = 0; i < index; i++)
        {
            total += values[i];
            Console.WriteLine(values[i]);
        }

        Console.WriteLine($"Total = {total}");
    }
}