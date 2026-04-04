using System;

public class MaximumNumberOfHandshakes
{
    public static void Main(String[] args)
    {
        Console.Write("Enter the number of people: ");
        int n = int.Parse(Console.ReadLine());

        // Maximum number of handshakes = n * (n - 1) / 2
        int maxHandshakes = n * (n - 1) / 2;

        Console.WriteLine("The maximum number of handshakes among " + n + " people is: " + maxHandshakes);
    }
}