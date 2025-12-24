using System;

class BMI2DArray
{
    static void Main()
    {
        Console.Write("Enter number of persons: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[][] personData = new double[n][];
        string[] status = new string[n];

        for (int i = 0; i < n; i++)
            personData[i] = new double[3];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter weight: ");
            personData[i][0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter height: ");
            personData[i][1] = Convert.ToDouble(Console.ReadLine());

            personData[i][2] = personData[i][0] / (personData[i][1] * personData[i][1]);

            if (personData[i][2] < 18.5) status[i] = "Underweight";
            else if (personData[i][2] < 25) status[i] = "Normal";
            else if (personData[i][2] < 30) status[i] = "Overweight";
            else status[i] = "Obese";
        }

        for (int i = 0; i < n; i++)
            Console.WriteLine($"H:{personData[i][1]} W:{personData[i][0]} BMI:{personData[i][2]} Status:{status[i]}");
    }
}