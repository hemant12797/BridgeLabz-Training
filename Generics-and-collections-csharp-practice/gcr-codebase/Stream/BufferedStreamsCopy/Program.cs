using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.Write("Source file: ");
        string src = Console.ReadLine();
        Console.Write("Destination base path: ");
        string dest = Console.ReadLine();

        byte[] buffer = new byte[4096];

        Stopwatch sw = Stopwatch.StartNew();
        using (FileStream fsIn = new FileStream(src, FileMode.Open))
        using (FileStream fsOut = new FileStream(dest + "_unbuffered", FileMode.Create))
        {
            int bytes;
            while ((bytes = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                fsOut.Write(buffer, 0, bytes);
        }
        sw.Stop();
        Console.WriteLine("Unbuffered Time: " + sw.ElapsedMilliseconds + " ms");

        sw.Restart();
        using (BufferedStream bsIn = new BufferedStream(new FileStream(src, FileMode.Open)))
        using (BufferedStream bsOut = new BufferedStream(new FileStream(dest + "_buffered", FileMode.Create)))
        {
            int bytes;
            while ((bytes = bsIn.Read(buffer, 0, buffer.Length)) > 0)
                bsOut.Write(buffer, 0, bytes);
        }
        sw.Stop();
        Console.WriteLine("Buffered Time: " + sw.ElapsedMilliseconds + " ms");
    }
}
