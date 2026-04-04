using System;

class TemperatureAnalyzer
{
    static void AnalyzeTemperature(float[,] temp)
    {
        int hottestDay = 0;
        int coldestDay = 0;

        float hottestAvg = float.MinValue;
        float coldestAvg = float.MaxValue;

        for (int i = 0; i < 7; i++)
        {
            float sum = 0;

            for (int j = 0; j < 24; j++)
            {
                sum += temp[i, j];
            }

            float avg = sum / 24;
            Console.WriteLine("Average temperature of Day " + (i + 1) + " : " + avg);

            if (avg > hottestAvg)
            {
                hottestAvg = avg;
                hottestDay = i;
            }

            if (avg < coldestAvg)
            {
                coldestAvg = avg;
                coldestDay = i;
            }
        }

        Console.WriteLine("\nHottest Day : Day " + (hottestDay + 1));
        Console.WriteLine("Coldest Day : Day " + (coldestDay + 1));
    }

    static void Main()
    {
        float[,] temperature = new float[7, 24];
        Random r = new Random();

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 24; j++)
            {
                temperature[i, j] = (float)(r.NextDouble() * (45 - 15) + 15);
            }
        }

        AnalyzeTemperature(temperature);
    }
}
