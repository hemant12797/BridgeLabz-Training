using System;

class Program
{
    static void Main(string[] args)
    {
        // Sample Aadhar numbers (12-digit strings)
        List<string> aadharNumbers = new List<string>
        {
            "123456789012",
            "987654321098",
            "111111111111",
            "222222222222",
            "333333333333",
            "444444444444",
            "555555555555",
            "666666666666",
            "777777777777",
            "888888888888"
        };

        Console.WriteLine("Original Aadhar Numbers:");
        foreach (var num in aadharNumbers)
        {
            Console.WriteLine(num);
        }

        // Scenario A: Sort all Aadhar numbers in ascending order using Radix Sort
        RadixSort(aadharNumbers);
        Console.WriteLine("\nSorted Aadhar Numbers (Ascending):");
        foreach (var num in aadharNumbers)
        {
            Console.WriteLine(num);
        }

        // Scenario B: Search for a particular number via binary search post-sorting
        string searchNumber = "333333333333";
        int index = BinarySearch(aadharNumbers, searchNumber);
        if (index != -1)
        {
            Console.WriteLine($"\nFound {searchNumber} at index {index}");
        }
        else
        {
            Console.WriteLine($"\n{searchNumber} not found");
        }

        // Scenario C: Maintain order of entries with same prefix (Radix Sort is stable)
        // Since Radix Sort is stable, same prefixes maintain relative order
        Console.WriteLine("\nRadix Sort maintains stability for same prefixes.");
    }

    // Radix Sort for strings (treating as numbers from right to left)
    static void RadixSort(List<string> arr)
    {
        int maxLen = arr.Max(s => s.Length);
        for (int pos = maxLen - 1; pos >= 0; pos--)
        {
            CountingSort(arr, pos);
        }
    }

    static void CountingSort(List<string> arr, int pos)
    {
        int n = arr.Count;
        List<string> output = new List<string>(new string[n]);
        int[] count = new int[10]; // Digits 0-9

        // Count occurrences
        for (int i = 0; i < n; i++)
        {
            int digit = pos < arr[i].Length ? arr[i][pos] - '0' : 0;
            count[digit]++;
        }

        // Cumulative count
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // Build output
        for (int i = n - 1; i >= 0; i--)
        {
            int digit = pos < arr[i].Length ? arr[i][pos] - '0' : 0;
            output[count[digit] - 1] = arr[i];
            count[digit]--;
        }

        // Copy back
        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
        }
    }

    // Binary Search for strings
    static int BinarySearch(List<string> arr, string target)
    {
        int left = 0, right = arr.Count - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int cmp = string.Compare(arr[mid], target);
            if (cmp == 0)
                return mid;
            else if (cmp < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}
