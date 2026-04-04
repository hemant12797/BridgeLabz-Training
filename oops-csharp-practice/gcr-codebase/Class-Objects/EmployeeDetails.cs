using System;
class EmployeeDetails
{
    private string name;
    private int id;
    private double salary;

    public EmployeeDetails(String name,int id,double salary)
    {
        this.name = name;
        this.id = id;
        this.salary = salary;
    }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"\n==================Details of {this.name}===================>\n");
        Console.WriteLine($"Name   :   {this.name}");
        Console.WriteLine($"ID     :   {this.id}");
        Console.WriteLine($"Salary :   {this.salary}");
    }
}