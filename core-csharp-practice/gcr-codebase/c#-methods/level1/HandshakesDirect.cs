using System;

class HandshakesDirect
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int handshakes = (n * (n - 1)) / 2;
        Console.WriteLine(handshakes);
    }
}