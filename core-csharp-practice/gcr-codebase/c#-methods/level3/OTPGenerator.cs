using System;

class OTPGenerator
{
    static int OTP()
    {
        Random r = new Random();
        return r.Next(100000, 999999);
    }

    static void Main()
    {
        int[] o = new int[10];
        for (int i = 0; i < 10; i++) o[i] = OTP();
        Console.WriteLine("Generated");
    }
}