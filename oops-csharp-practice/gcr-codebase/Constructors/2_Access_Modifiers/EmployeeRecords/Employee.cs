
class Employee
{
    public int employeeID;
    protected string department;
    private double salary;

    public void SetSalary(double s)
    {
        salary = s;
    }

    public double GetSalary()
    {
        return salary;
    }
}

class Manager : Employee
{
    public void ShowEmployee()
    {
        System.Console.WriteLine(employeeID + " " + department);
    }
}
