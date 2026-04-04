using System;

public class CalculateDiscountUserInput
{
    public static void Main(String[] args)
    {
        int fee = int.Parse(Console.ReadLine());

        int discountPercent = int.Parse(Console.ReadLine());

        float discountAmount = (float)fee / discountPercent;

        float discountedFee = fee - discountAmount;

        Console.WriteLine("The discount amount is INR " + discountAmount +" and final discounted fee is INR "+ discountedFee);
    }
}