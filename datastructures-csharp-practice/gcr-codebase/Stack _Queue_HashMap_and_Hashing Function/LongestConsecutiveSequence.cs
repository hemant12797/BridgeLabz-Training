using System;
using System.Collections.Generic;

class Program
{
    static int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0) return 0;

        HashSet<int> numSet = new HashSet<int>(nums);
        int maxLength = 0;

        foreach (int num in nums)
        {
            // Check if this is the start of a sequence
            if (!numSet.Contains(num - 1))
            {
                int currentNum = num;
                int currentLength = 1;

                // Extend the sequence
                while (numSet.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentLength++;
                }

                maxLength = Math.Max(maxLength, currentLength);
            }
        }

        return maxLength;
    }

    static void Main()
    {
        int[] nums = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine("Array: " + string.Join(", ", nums));
        Console.WriteLine("Length of longest consecutive sequence: " + LongestConsecutive(nums));
    }
}
