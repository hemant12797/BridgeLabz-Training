using System;
using System.Collections.Generic;

class MetalFactoryPipeCutting
{
    // Rod Cutting DP Function
    static int MaxRevenue(int[] price, int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            int maxVal = int.MinValue;
            for (int j = 1; j <= i; j++)
            {
                maxVal = Math.Max(maxVal, price[j] + dp[i - j]);
            }
            dp[i] = maxVal;
        }
        return dp[n];
    }

    // Non-optimized strategy (no cuts)
    static int NonOptimizedRevenue(int[] price, int length)
    {
        return price[length];
    }

    static void Main()
    {
        // Price chart (index = length)
        int[] price = { 0, 1, 5, 8, 9, 10, 17, 17, 20 };

        int rodLength = 8;

        // Scenario A
        Console.WriteLine("Scenario A: Optimized Revenue");
        Console.WriteLine("Max Revenue: " + MaxRevenue(price, rodLength));

        // Scenario B: Custom length added
        Console.WriteLine("\nScenario B: Custom Length Order (length 9)");
        Array.Resize(ref price, 10);
        price[9] = 24; // Custom price
        Console.WriteLine("Max Revenue for length 9: " + MaxRevenue(price, 9));

        // Scenario C
        Console.WriteLine("\nScenario C: Non-Optimized Strategy");
        Console.WriteLine("Revenue without cuts: " + NonOptimizedRevenue(price, rodLength));
    }
}
