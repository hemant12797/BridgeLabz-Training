using System;

public class CalculateProfit
{
    public static void Main(String[] args)
    {
        int costPrice = 129;
        int sellingPrice = 191;

        int profit = sellingPrice - costPrice;

        float profitPercentage = (float)profit / costPrice * 100f;

        Console.WriteLine("The Cost Price is INR "+ costPrice +" and Selling Price is INR "+ sellingPrice);
        Console.WriteLine("The Profit is INR "+ profit +" and the Profit Percentage is "+ profitPercentage);
    }
}