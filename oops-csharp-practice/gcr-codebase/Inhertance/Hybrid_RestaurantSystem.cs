
interface Worker
{
    void PerformDuties();
}

class Person
{
    public string Name;
    public int Id;
}

class Chef : Person, Worker
{
    public void PerformDuties()
    {
        System.Console.WriteLine("Chef cooks food");
    }
}

class Waiter : Person, Worker
{
    public void PerformDuties()
    {
        System.Console.WriteLine("Waiter serves food");
    }
}
