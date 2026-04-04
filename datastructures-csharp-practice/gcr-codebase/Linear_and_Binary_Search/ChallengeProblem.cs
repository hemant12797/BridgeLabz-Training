using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        List<int> list = new List<int> { 3, 4, -1, 1 };
        int missingPositive = FindFirstMissingPositive(list);
        Console.WriteLine($"First missing positive integer: {missingPositive}");

        int[] arr = list.ToArray();
        Array.Sort(arr);
        int target = 1;
        int index = BinarySearch(arr, target);
        Console.WriteLine($"Index of target {target}: {index}");
    }

    static int FindFirstMissingPositive(List<int> list) {
        int n = list.Count;
        for (int i = 0; i < n; i++) {
            while (list[i] > 0 && list[i] <= n && list[list[i] - 1] != list[i]) {
                int temp = list[list[i] - 1];
                list[list[i] - 1] = list[i];
                list[i] = temp;
            }
        }
        for (int i = 0; i < n; i++) {
            if (list[i] != i + 1) {
                return i + 1;
            }
        }
        return n + 1;
    }

    static int BinarySearch(int[] arr, int target) {
        int low = 0, high = arr.Length - 1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (arr[mid] == target) {
                return mid;
            } else if (arr[mid] < target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return -1;
    }
}
