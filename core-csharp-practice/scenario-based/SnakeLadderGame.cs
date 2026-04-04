using System;
using System.Collections.Generic;

class SnakeLadderGame
{
    static int[] playerPositions;
    static Random random = new Random();
    static Dictionary<int, int> snakeLadderMap = new Dictionary<int, int>();

    SnakeLadderGame()
    {
        snakeLadderMap.Add(35, 4);
        snakeLadderMap.Add(48, 26);
        snakeLadderMap.Add(53, 21);
        snakeLadderMap.Add(88, 60);
        snakeLadderMap.Add(93, 65);
        snakeLadderMap.Add(3, 32);
        snakeLadderMap.Add(19, 28);
        snakeLadderMap.Add(34, 52);
        snakeLadderMap.Add(39, 79);
        snakeLadderMap.Add(46, 67);
        snakeLadderMap.Add(61, 82);
        snakeLadderMap.Add(65, 87);
    }

    public static void Main()
    {
        new SnakeLadderGame();

        Console.WriteLine("Enter number of players (minimum 2 and maximum 4)");
        int playerCount = Convert.ToInt16(Console.ReadLine());

        if (playerCount < 2 || playerCount > 4)
        {
            Console.WriteLine("Invalid number");
            return;
        }

        playerPositions = new int[playerCount];
        bool isGameWon = false;

        while (!isGameWon)
        {
            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine($"Player {i + 1} turn. Press any key to continue or 'N' to exit:");
                string choice = Console.ReadLine();
                if (choice.Equals("N")) return;

                int previousPosition = playerPositions[i];
                int diceValue = RollDice();
                int start = 0, end = 0;

                MovePlayer(i, diceValue, ref start, ref end);

                Console.WriteLine($"Player - {i + 1}");
                Console.WriteLine($"Dice Value - {diceValue}");
                Console.WriteLine($"Old Position - {previousPosition}");
                Console.WriteLine($"New Position - {playerPositions[i]}");

                if (end < start)
                    Console.WriteLine($"Snake bite 😂 {start} 🐍 {end}\n");
                else if (start < end)
                    Console.WriteLine($"Ladder 👌 {start} 🪜 {end}\n");

                if (CheckWin(i))
                {
                    Console.WriteLine($"Congratulations!! Player {i + 1} wins the match");
                    isGameWon = true;
                    break;
                }
            }
        }
    }

    static int RollDice() => random.Next(1, 7);

    static void MovePlayer(int playerIndex, int dicePoints, ref int start, ref int end)
    {
        int newPosition = playerPositions[playerIndex] + dicePoints;
        if (newPosition > 100) return;

        if (snakeLadderMap.ContainsKey(newPosition))
        {
            start = newPosition;
            newPosition = snakeLadderMap[newPosition];
            end = newPosition;
        }

        playerPositions[playerIndex] = newPosition;
    }

    static bool CheckWin(int playerIndex) => playerPositions[playerIndex] == 100;
}
