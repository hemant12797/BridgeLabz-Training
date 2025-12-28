using System;

class NumberGuessingGame
{
    static void Main()
    {
        int low = 1, high = 100;
        string feedback = "";

        Console.WriteLine("Think of a number between 1 and 100.");

        while (feedback != "correct")
        {
            int guess = GenerateGuess(low, high);
            Console.WriteLine("Is your number " + guess + "? (high/low/correct)");
            feedback = Console.ReadLine().ToLower();

            if (feedback == "high")
                high = guess - 1;
            else if (feedback == "low")
                low = guess + 1;
        }

        Console.WriteLine("Number guessed successfully!");
    }

    static int GenerateGuess(int low, int high)
    {
        Random rand = new Random();
        return rand.Next(low, high + 1);
    }
}