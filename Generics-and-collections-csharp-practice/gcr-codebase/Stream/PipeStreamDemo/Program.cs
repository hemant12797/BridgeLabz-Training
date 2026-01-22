using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class Program
{
    static void Main()
    {
        using AnonymousPipeServerStream server = new(PipeDirection.Out);
        using AnonymousPipeClientStream client = new(PipeDirection.In, server.ClientSafePipeHandle);

        Thread writer = new(() =>
        {
            using StreamWriter sw = new StreamWriter(server) { AutoFlush = true };
            sw.WriteLine("Hello from writer");
        });

        Thread reader = new(() =>
        {
            using StreamReader sr = new StreamReader(client);
            Console.WriteLine(sr.ReadLine());
        });

        writer.Start();
        reader.Start();
        writer.Join();
        reader.Join();
    }
}
