using System;
using System.Collections.Generic;

class Program
{
    static bool HasPairWithSum(int[] arr, int target)
    {
        HashSet<int> seen = new HashSet<int>();
        foreach (int num in arr)
        {
            int complement = target - num;
            if (seen.Contains(complement))
            {
                return true;
            }
            seen.Add(num);
        }
        return false;
    }

    static void Main()
    {
        int[] arr = { 1, 4, 45, 6, 10, 8 };
        int target = 16;
        Console.WriteLine("Array: " + string.Join(", ", arr));
        Console.WriteLine("Target sum: " + target);
        if (HasPairWithSum(arr, target))
        {
            Console.WriteLine("Yes, there is a pair with sum " + target);
        }
        else
        {
            Console.WriteLine("No pair found with sum " + target);
        }
    }
}
