using System;

class CustomFurnitureManufacturing
{
    static int MaxRevenueWithWasteConstraint(int[] price, int n, int maxWaste)
    {
        int[] dp = new int[n + 1];
        dp[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            int maxVal = price[i]; // no cut
            for (int j = 1; j <= i; j++)
            {
                int waste = i - j;
                if (waste <= maxWaste)
                {
                    maxVal = Math.Max(maxVal, price[j] + dp[i - j]);
                }
            }
            dp[i] = maxVal;
        }
        return dp[n];
    }

    static int MaxRevenueMinWaste(int[] price, int n)
    {
        int[] dp = new int[n + 1];
        int[] waste = new int[n + 1];

        dp[0] = 0;
        waste[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            dp[i] = price[i];
            waste[i] = n - i;

            for (int j = 1; j <= i; j++)
            {
                int revenue = price[j] + dp[i - j];
                int currentWaste = waste[i - j];

                if (revenue > dp[i] ||
                   (revenue == dp[i] && currentWaste < waste[i]))
                {
                    dp[i] = revenue;
                    waste[i] = currentWaste;
                }
            }
        }
        return dp[n];
    }

    static void Main()
    {
        int[] price = { 0, 2, 6, 7, 10, 13, 17, 18, 20, 24, 30, 33, 36 };
        int rodLength = 12;

        // Scenario A
        Console.WriteLine("Scenario A: Max Revenue for 12 ft rod");
        Console.WriteLine("Max Revenue: " + MaxRevenueMinWaste(price, rodLength));

        // Scenario B
        Console.WriteLine("\nScenario B: Waste Constraint (Max waste = 1 ft)");
        Console.WriteLine("Revenue with waste constraint: " +
            MaxRevenueWithWasteConstraint(price, rodLength, 1));

        // Scenario C
        Console.WriteLine("\nScenario C: Max Revenue with Minimal Waste");
        Console.WriteLine("Optimized Revenue: " + MaxRevenueMinWaste(price, rodLength));
    }
}
