using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = { 1000, 10000, 1000000 };
        Random rand = new Random();
        int target = rand.Next(0, 1000001); // Target within possible range

        foreach (int size in sizes)
        {
            int[] data = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = rand.Next(0, 1000001);
            }

            // Linear Search
            Stopwatch sw = Stopwatch.StartNew();
            int linearResult = LinearSearch(data, target);
            sw.Stop();
            Console.WriteLine($"Linear Search for size {size}: {sw.ElapsedMilliseconds} ms, Found: {linearResult != -1}");

            // Binary Search (sort first)
            Array.Sort(data);
            sw.Restart();
            int binaryResult = BinarySearch(data, target);
            sw.Stop();
            Console.WriteLine($"Binary Search for size {size}: {sw.ElapsedMilliseconds} ms, Found: {binaryResult != -1}");
        }
    }

    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target) return i;
        }
        return -1;
    }

    static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target) return mid;
            if (arr[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }
}
