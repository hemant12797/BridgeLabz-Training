using System;

class Program {
    static void Main() {
        try {
            int[] arr = {1,2,3};
            Console.Write("Enter index: ");
            int idx = int.Parse(Console.ReadLine());
            Console.WriteLine($"Value at index {idx}: {arr[idx]}");
        } catch (IndexOutOfRangeException) {
            Console.WriteLine("Invalid index!");
        } catch (NullReferenceException) {
            Console.WriteLine("Array is not initialized!");
        }
    }
}