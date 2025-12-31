using System;

class BankAccount
{
    // Fields / Properties
    public string AccountNumber { get; private set; }
    public double Balance { get; private set; }

    // Constructor
    public BankAccount(string accountNumber, double initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    // Deposit Method
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"₹{amount} deposited successfully.");
        }
        else
        {
            Console.WriteLine("Deposit amount must be greater than zero.");
        }
    }

    // Withdraw Method (Overdraft Protection)
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be greater than zero.");
        }
        else if (amount > Balance)
        {
            Console.WriteLine("Insufficient balance! Overdraft not allowed.");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"₹{amount} withdrawn successfully.");
        }
    }

    // Check Balance Method
    public void CheckBalance()
    {
        Console.WriteLine($"Current Balance: ₹{Balance}");
    }
}

class Program
{
    static void Main()
    {
        // Create bank account
        BankAccount account = new BankAccount("ACC12345", 5000);

        // Perform operations
        account.CheckBalance();
        account.Deposit(2000);
        account.Withdraw(1000);
        account.Withdraw(7000); // Overdraft attempt
        account.CheckBalance();
    }
}
