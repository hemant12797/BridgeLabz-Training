using System;

class BonusCalculation
{
    static void Main()
    {
        double[] salary = new double[10];
        double[] years = new double[10];
        double[] bonus = new double[10];
        double[] newSalary = new double[10];

        double totalBonus = 0, totalOldSalary = 0, totalNewSalary = 0;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Employee {i + 1}");
            Console.Write("Enter Salary: ");
            double s = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Years of Service: ");
            double y = Convert.ToDouble(Console.ReadLine());

            if (s <= 0 || y < 0)
            {
                Console.WriteLine("Invalid input. Re-enter details.");
                i--;
                continue;
            }

            salary[i] = s;
            years[i] = y;
        }

        for (int i = 0; i < 10; i++)
        {
            bonus[i] = years[i] > 5 ? salary[i] * 0.05 : salary[i] * 0.02;
            newSalary[i] = salary[i] + bonus[i];

            totalBonus += bonus[i];
            totalOldSalary += salary[i];
            totalNewSalary += newSalary[i];
        }

        Console.WriteLine($"Total Bonus = {totalBonus}");
        Console.WriteLine($"Total Old Salary = {totalOldSalary}");
        Console.WriteLine($"Total New Salary = {totalNewSalary}");
    }
}