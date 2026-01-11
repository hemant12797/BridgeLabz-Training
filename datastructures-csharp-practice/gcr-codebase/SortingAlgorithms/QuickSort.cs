using System;

class QuickSort {
    static int Partition(int[] arr, int low, int high) {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++) {
            if (arr[j] < pivot) {
                i++;
                int temp = arr[i]; arr[i] = arr[j]; arr[j] = temp;
            }
        }
        int t = arr[i + 1]; arr[i + 1] = arr[high]; arr[high] = t;
        return i + 1;
    }

    static void Sort(int[] arr, int low, int high) {
        if (low < high) {
            int pi = Partition(arr, low, high);
            Sort(arr, low, pi - 1);
            Sort(arr, pi + 1, high);
        }
    }

    static void Main() {
        int[] prices = {999, 499, 199, 799};
        Sort(prices, 0, prices.Length - 1);
        Console.WriteLine("Sorted Product Prices:");
        foreach (int p in prices) Console.Write(p + " ");
    }
}