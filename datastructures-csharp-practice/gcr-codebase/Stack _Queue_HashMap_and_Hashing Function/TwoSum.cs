using System;
using System.Collections.Generic;

class Program
{
    static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i };
            }
            map[nums[i]] = i;
        }
        return new int[] { -1, -1 }; // No solution found
    }

    static void Main()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        Console.WriteLine("Array: " + string.Join(", ", nums));
        Console.WriteLine("Target: " + target);
        int[] result = TwoSum(nums, target);
        if (result[0] != -1)
        {
            Console.WriteLine("Indices: [" + result[0] + ", " + result[1] + "]");
        }
        else
        {
            Console.WriteLine("No two sum solution");
        }
    }
}
