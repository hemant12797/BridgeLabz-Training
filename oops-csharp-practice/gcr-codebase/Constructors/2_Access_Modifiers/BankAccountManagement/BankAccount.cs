
class BankAccount
{
    public int accountNumber;
    protected string accountHolder;
    private double balance;

    public void SetBalance(double amt)
    {
        balance = amt;
    }

    public double GetBalance()
    {
        return balance;
    }
}

class SavingsAccount : BankAccount
{
    public void ShowAccount()
    {
        System.Console.WriteLine(accountNumber + " " + accountHolder);
    }
}
