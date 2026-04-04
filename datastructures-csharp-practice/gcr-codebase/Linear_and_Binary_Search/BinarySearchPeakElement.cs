using System;

class Program {
    static void Main() {
        int[] arr = { 1, 3, 20, 4, 1, 0 };
        int peak = FindPeakElement(arr);
        Console.WriteLine($"Peak element is {arr[peak]} at index {peak}");
    }

    static int FindPeakElement(int[] arr) {
        int low = 0, high = arr.Length - 1;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (arr[mid] < arr[mid + 1]) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }
        return low;
    }
}
