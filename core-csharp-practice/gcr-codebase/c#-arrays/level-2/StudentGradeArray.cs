using System;

class StudentGradeArray
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] percent = new double[n];
        char[] grade = new char[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Student {i + 1}");
            double p = Convert.ToDouble(Console.ReadLine());
            double c = Convert.ToDouble(Console.ReadLine());
            double m = Convert.ToDouble(Console.ReadLine());

            percent[i] = (p + c + m) / 3;

            if (percent[i] >= 80) grade[i] = 'A';
            else if (percent[i] >= 70) grade[i] = 'B';
            else if (percent[i] >= 60) grade[i] = 'C';
            else if (percent[i] >= 50) grade[i] = 'D';
            else if (percent[i] >= 40) grade[i] = 'E';
            else grade[i] = 'R';
        }

        for (int i = 0; i < n; i++)
            Console.WriteLine($"Percentage:{percent[i]} Grade:{grade[i]}");
    }
}