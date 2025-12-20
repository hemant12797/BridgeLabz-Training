using System;

public class CalculateDiscount
{
    public static void Main(String[] args)
    {
        int fee = 125000;

        int discountPercent = 10;

        float discountAmount = (float)fee / discountPercent;

        float discountedFee = fee - discountAmount;

        Console.WriteLine("The discount amount is INR " + discountAmount +" and final discounted fee is INR "+ discountedFee);
    }
}