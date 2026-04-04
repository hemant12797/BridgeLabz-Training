
class BankAccount
{
    public int AccountNumber;
    public double Balance;
}

class SavingsAccount : BankAccount
{
    public double InterestRate;
    public void DisplayAccountType()
    {
        System.Console.WriteLine("Savings Account");
    }
}

class CheckingAccount : BankAccount
{
    public int WithdrawalLimit;
    public void DisplayAccountType()
    {
        System.Console.WriteLine("Checking Account");
    }
}

class FixedDepositAccount : BankAccount
{
    public int LockInPeriod;
    public void DisplayAccountType()
    {
        System.Console.WriteLine("Fixed Deposit Account");
    }
}
