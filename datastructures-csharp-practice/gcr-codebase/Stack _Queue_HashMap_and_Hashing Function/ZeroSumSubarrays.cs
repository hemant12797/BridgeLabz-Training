using System;
using System.Collections.Generic;

class Program
{
    static void FindZeroSumSubarrays(int[] arr)
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        int sum = 0;
        map[0] = new List<int> { -1 }; // To handle subarrays starting from index 0

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            if (!map.ContainsKey(sum))
            {
                map[sum] = new List<int>();
            }
            map[sum].Add(i);
        }

        // Now, find all subarrays where sum is zero
        foreach (var kvp in map)
        {
            var indices = kvp.Value;
            if (indices.Count > 1)
            {
                for (int j = 0; j < indices.Count; j++)
                {
                    for (int k = j + 1; k < indices.Count; k++)
                    {
                        int start = indices[j] + 1;
                        int end = indices[k];
                        Console.Write($"Subarray from index {start} to {end}: ");
                        for (int p = start; p <= end; p++)
                        {
                            Console.Write(arr[p] + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }

    static void Main()
    {
        int[] arr = { 1, 2, -3, 3, -1, 2 };
        Console.WriteLine("Array: " + string.Join(", ", arr));
        Console.WriteLine("Zero-sum subarrays:");
        FindZeroSumSubarrays(arr);
    }
}
