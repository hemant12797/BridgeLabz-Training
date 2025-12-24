using System;

class MatrixCopy
{
    static void Main()
    {
        Console.Write("Enter rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter columns: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[rows, cols];
        int[] array = new int[rows * cols];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Enter element [{i},{j}]: ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                array[index++] = matrix[i, j];
            }
        }

        Console.WriteLine("1D Array:");
        foreach (int value in array)
            Console.Write(value + " ");
    }
}