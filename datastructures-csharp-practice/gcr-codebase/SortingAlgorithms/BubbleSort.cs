using System;

class BubbleSort {
    static void Main() {
        int[] marks = {78, 45, 89, 60, 72};
        for (int i = 0; i < marks.Length - 1; i++) {
            for (int j = 0; j < marks.Length - i - 1; j++) {
                if (marks[j] > marks[j + 1]) {
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Sorted Marks:");
        foreach (int m in marks) Console.Write(m + " ");
    }
}
