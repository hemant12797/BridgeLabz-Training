using System;

class StudentVoteChecker
{
    static bool CanStudentVote(int age)
    {
        if (age < 0) return false;
        return age >= 18;
    }

    static void Main()
    {
        int[] ages = new int[10];
        for (int i = 0; i < ages.Length; i++)
        {
            ages[i] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(CanStudentVote(ages[i]));
        }
    }
}