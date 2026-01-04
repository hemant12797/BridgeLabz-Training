
using System.Collections.Generic;

class Company
{
    public List<Department> Departments = new List<Department>();
}

class Department
{
    public string Name;
    public List<Employee> Employees = new List<Employee>();

    public Department(string name)
    {
        Name = name;
    }
}

class Employee
{
    public string Name;
    public Employee(string name)
    {
        Name = name;
    }
}
