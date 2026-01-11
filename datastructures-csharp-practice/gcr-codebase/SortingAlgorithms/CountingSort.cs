using System;

class CountingSort {
    static void Main() {
        int[] ages = {12, 15, 10, 14, 18, 12};
        int min = 10, max = 18;
        int[] count = new int[max - min + 1];

        foreach (int age in ages) count[age - min]++;

        int index = 0;
        for (int i = 0; i < count.Length; i++) {
            while (count[i]-- > 0) ages[index++] = i + min;
        }

        Console.WriteLine("Sorted Student Ages:");
        foreach (int a in ages) Console.Write(a + " ");
    }
}