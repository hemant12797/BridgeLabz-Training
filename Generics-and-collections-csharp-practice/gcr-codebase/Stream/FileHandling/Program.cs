using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string sourceFile = "source.txt";
        string destinationFile = "destination.txt";

        try
        {
            // Check if source file exists
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("The source file does not exist.");
                return;
            }

            // Use FileStream to read from source and write to destination
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (FileStream destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
            {
                sourceStream.CopyTo(destinationStream);
            }

            Console.WriteLine("File copied successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
