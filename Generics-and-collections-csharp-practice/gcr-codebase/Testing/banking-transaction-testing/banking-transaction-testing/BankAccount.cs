namespace BankingTransactionTesting
{
    public class BankAccount
    {
        private double balance;

        public void Deposit(double amount)
        {
            balance = balance + amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new InvalidOperationException();
            }

            balance = balance - amount;
        }

        public double GetBalance()
        {
            return balance;
        }
    }
}
