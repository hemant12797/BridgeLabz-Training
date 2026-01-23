using System;

class Program {
    static void Main() {
        int[] arr = {10,20,30};
        try {
            try {
                Console.WriteLine(arr[5] / 0);
            } catch (DivideByZeroException) {
                Console.WriteLine("Cannot divide by zero!");
            }
        } catch (IndexOutOfRangeException) {
            Console.WriteLine("Invalid array index!");
        }
    }
}