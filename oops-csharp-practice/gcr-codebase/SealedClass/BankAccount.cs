
class BankAccount
{
    public static string BankName = "State Bank";
    private static int totalAccounts = 0;

    public string AccountHolderName;
    public readonly int AccountNumber;

    public BankAccount(string name, int accNo)
    {
        this.AccountHolderName = name;
        this.AccountNumber = accNo;
        totalAccounts++;
    }

    public static void GetTotalAccounts()
    {
        System.Console.WriteLine("Total Accounts: " + totalAccounts);
    }

    public void DisplayDetails(object obj)
    {
        if (obj is BankAccount)
            System.Console.WriteLine(AccountHolderName + " " + AccountNumber + " " + BankName);
    }
}
