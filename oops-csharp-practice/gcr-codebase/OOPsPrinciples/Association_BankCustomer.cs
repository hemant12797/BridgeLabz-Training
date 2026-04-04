
class Bank
{
    public string BankName;

    public Bank(string name)
    {
        BankName = name;
    }

    public void OpenAccount(Customer customer)
    {
        System.Console.WriteLine(customer.Name + " opened account in " + BankName);
    }
}

class Customer
{
    public string Name;
    public double Balance;

    public Customer(string name, double balance)
    {
        Name = name;
        Balance = balance;
    }

    public void ViewBalance()
    {
        System.Console.WriteLine("Balance: " + Balance);
    }
}
