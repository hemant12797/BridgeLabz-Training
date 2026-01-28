using System;

class InsufficientFundsException : Exception {}

class BankAccount {
    public double Balance = 500;

    public void Withdraw(double amount) {
        if (amount < 0) throw new ArgumentException();
        if (amount > Balance) throw new InsufficientFundsException();
        Balance -= amount;
    }
}

class Program {
    static void Main() {
        BankAccount acc = new BankAccount();
        try {
            acc.Withdraw(600);
            Console.WriteLine("Withdrawal successful, new balance: " + acc.Balance);
        } catch (InsufficientFundsException) {
            Console.WriteLine("Insufficient balance!");
        } catch (ArgumentException) {
            Console.WriteLine("Invalid amount!");
        }
    }
}