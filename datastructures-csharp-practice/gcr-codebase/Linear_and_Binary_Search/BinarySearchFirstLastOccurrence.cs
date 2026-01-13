using System;

class Program {
    static void Main() {
        int[] arr = { 1, 2, 2, 2, 3, 4, 5 };
        int target = 2;
        int[] result = FindFirstAndLast(arr, target);
        Console.WriteLine($"First occurrence: {result[0]}, Last occurrence: {result[1]}");
    }

    static int[] FindFirstAndLast(int[] arr, int target) {
        int first = FindFirst(arr, target);
        int last = FindLast(arr, target);
        return new int[] { first, last };
    }

    static int FindFirst(int[] arr, int target) {
        int low = 0, high = arr.Length - 1;
        int result = -1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (arr[mid] == target) {
                result = mid;
                high = mid - 1;
            } else if (arr[mid] < target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return result;
    }

    static int FindLast(int[] arr, int target) {
        int low = 0, high = arr.Length - 1;
        int result = -1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (arr[mid] == target) {
                result = mid;
                low = mid + 1;
            } else if (arr[mid] < target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return result;
    }
}
