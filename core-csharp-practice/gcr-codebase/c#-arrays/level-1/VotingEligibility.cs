using System;

class VotingEligibility
{
    static void Main()
    {
        int[] ages = new int[10];

        for (int i = 0; i < ages.Length; i++)
        {
            Console.Write($"Enter age of student {i + 1}: ");
            ages[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine();

        foreach (int age in ages)
        {
            if (age < 0)
            {
                Console.WriteLine("Invalid age");
            }
            else if (age >= 18)
            {
                Console.WriteLine($"The student with the age {age} can vote.");
            }
            else
            {
                Console.WriteLine($"The student with the age {age} cannot vote.");
            }
        }
    }
}