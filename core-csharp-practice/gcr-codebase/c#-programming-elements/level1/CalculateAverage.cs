using System;

public class CalculateAverage
{
    public static void Main(String[] args)
    {
        int mathsMarks = 94;
        int physicsMarks = 95;
        int chemistryMarks = 96;

        float avrg = (mathsMarks + physicsMarks + chemistryMarks) / 3f;

        Console.WriteLine("Sam’s average mark in PCM is "+ (avrg));
    }
}