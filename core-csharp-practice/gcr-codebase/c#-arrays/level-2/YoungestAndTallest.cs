using System;

class YoungestAndTallest
{
    static void Main()
    {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] age = new int[3];
        double[] height = new double[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter age of {names[i]}: ");
            age[i] = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Enter height of {names[i]}: ");
            height[i] = Convert.ToDouble(Console.ReadLine());
        }

        int youngestIndex = 0, tallestIndex = 0;

        for (int i = 1; i < 3; i++)
        {
            if (age[i] < age[youngestIndex])
                youngestIndex = i;

            if (height[i] > height[tallestIndex])
                tallestIndex = i;
        }

        Console.WriteLine($"Youngest: {names[youngestIndex]}");
        Console.WriteLine($"Tallest: {names[tallestIndex]}");
    }
}