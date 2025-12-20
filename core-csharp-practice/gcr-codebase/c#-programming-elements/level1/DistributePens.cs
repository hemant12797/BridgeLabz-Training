using System;

public class DistributePens
{
    public static void Main(String[] args)
    {
        int totalPens = 14;
        int noOfStudents = 3;

        int pensPerStudent = totalPens / noOfStudents;

        int remainingPens = totalPens % noOfStudents;

        Console.WriteLine("The Pen Per Student is "+ pensPerStudent +" and the remaining pen not distributed is "+ remainingPens);

    }
}