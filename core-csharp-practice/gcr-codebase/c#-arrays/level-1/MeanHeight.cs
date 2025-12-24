using System;

class MeanHeight
{
    static void Main()
    {
        double[] heights = new double[11];
        double sum = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            Console.Write($"Enter height of player {i + 1}: ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
            sum += heights[i];
        }

        double mean = sum / heights.Length;
        Console.WriteLine($"Mean height = {mean}");
    }
}