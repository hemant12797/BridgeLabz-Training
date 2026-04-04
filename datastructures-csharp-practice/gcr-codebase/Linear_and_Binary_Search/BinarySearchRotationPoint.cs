using System;

class Program {
    static void Main() {
        int[] arr = { 4, 5, 6, 7, 0, 1, 2 };
        int index = FindRotationPoint(arr);
        Console.WriteLine($"Rotation point is at index {index}, value {arr[index]}");
    }

    static int FindRotationPoint(int[] arr) {
        int low = 0, high = arr.Length - 1;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (arr[mid] > arr[high]) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }
        return low;
    }
}
