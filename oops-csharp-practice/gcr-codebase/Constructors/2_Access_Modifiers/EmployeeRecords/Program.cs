
using System;
class Program
{
    static void Main()
    {
        Manager m = new Manager();
        m.employeeID = 1;
        m.SetSalary(60000);
        Console.WriteLine(m.GetSalary());
    }
}
