using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Image path: ");
            string path = Console.ReadLine();

            byte[] bytes = File.ReadAllBytes(path);
            using MemoryStream ms = new MemoryStream(bytes);
            File.WriteAllBytes("copy_" + Path.GetFileName(path), ms.ToArray());

            Console.WriteLine("Image copied successfully");
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
