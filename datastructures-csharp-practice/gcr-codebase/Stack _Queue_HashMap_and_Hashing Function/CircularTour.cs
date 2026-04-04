using System;
using System.Collections.Generic;

public class PetrolPump
{
    public int Petrol { get; set; }
    public int Distance { get; set; }

    public PetrolPump(int petrol, int distance)
    {
        Petrol = petrol;
        Distance = distance;
    }
}

public class CircularTour
{
    public int FindStart(PetrolPump[] pumps)
    {
        int n = pumps.Length;
        int start = 0;
        int surplus = 0;
        int total = 0;

        for (int i = 0; i < n; i++)
        {
            surplus += pumps[i].Petrol - pumps[i].Distance;
            total += pumps[i].Petrol - pumps[i].Distance;

            if (surplus < 0)
            {
                start = i + 1;
                surplus = 0;
            }
        }

        return total >= 0 ? start : -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        PetrolPump[] pumps = new PetrolPump[]
        {
            new PetrolPump(6, 4),
            new PetrolPump(3, 6),
            new PetrolPump(7, 3)
        };

        CircularTour tour = new CircularTour();
        int start = tour.FindStart(pumps);

        if (start != -1)
        {
            Console.WriteLine("Start at pump: " + start);
        }
        else
        {
            Console.WriteLine("No solution");
        }
    }
}
