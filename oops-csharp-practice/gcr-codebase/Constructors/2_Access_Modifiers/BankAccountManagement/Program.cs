
using System;
class Program
{
    static void Main()
    {
        SavingsAccount sa = new SavingsAccount();
        sa.accountNumber = 101;
        sa.SetBalance(5000);
        Console.WriteLine(sa.GetBalance());
    }
}
