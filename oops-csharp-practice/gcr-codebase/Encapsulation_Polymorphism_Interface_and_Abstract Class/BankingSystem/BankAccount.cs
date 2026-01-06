using System;

namespace BankingSystem
{
    public abstract class BankAccount
    {
        private int accountNumber;
        private string holderName;
        private double balance;

        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public string HolderName
        {
            get { return holderName; }
            set { holderName = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public abstract double CalculateInterest();
    }
}
