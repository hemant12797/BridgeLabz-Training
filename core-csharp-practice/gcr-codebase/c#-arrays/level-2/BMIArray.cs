using System;

class BMIArray
{
    static void Main()
    {
        Console.Write("Enter number of persons: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] weight = new double[n];
        double[] height = new double[n];
        double[] bmi = new double[n];
        string[] status = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter weight of person {i + 1}: ");
            weight[i] = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Enter height of person {i + 1}: ");
            height[i] = Convert.ToDouble(Console.ReadLine());

            bmi[i] = weight[i] / (height[i] * height[i]);

            if (bmi[i] < 18.5) status[i] = "Underweight";
            else if (bmi[i] < 25) status[i] = "Normal";
            else if (bmi[i] < 30) status[i] = "Overweight";
            else status[i] = "Obese";
        }

        for (int i = 0; i < n; i++)
            Console.WriteLine($"Height:{height[i]} Weight:{weight[i]} BMI:{bmi[i]} Status:{status[i]}");
    }
}