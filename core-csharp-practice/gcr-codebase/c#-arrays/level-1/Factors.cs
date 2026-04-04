using System;

class Factors
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int size = 10;
        int[] factors = new int[size];
        int index = 0;

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                if (index == size)
                {
                    size *= 2;
                    int[] temp = new int[size];
                    factors.CopyTo(temp, 0);
                    factors = temp;
                }

                factors[index++] = i;
            }
        }

        Console.WriteLine("Factors:");
        for (int i = 0; i < index; i++)
            Console.Write(factors[i] + " ");
    }
}