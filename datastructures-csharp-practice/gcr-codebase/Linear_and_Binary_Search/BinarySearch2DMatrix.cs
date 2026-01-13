using System;

class Program {
    static void Main() {
        int[][] matrix = {
            new int[] {1, 4, 7, 11},
            new int[] {2, 5, 8, 12},
            new int[] {3, 6, 9, 16}
        };
        int target = 5;
        bool found = SearchMatrix(matrix, target);
        Console.WriteLine($"Target {target} found: {found}");
    }

    static bool SearchMatrix(int[][] matrix, int target) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return false;
        int rows = matrix.Length, cols = matrix[0].Length;
        int low = 0, high = rows * cols - 1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            int row = mid / cols;
            int col = mid % cols;
            if (matrix[row][col] == target) {
                return true;
            } else if (matrix[row][col] < target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return false;
    }
}
