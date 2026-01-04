
using System.Collections.Generic;

class University
{
    public List<Department> Departments = new List<Department>();
    public List<Faculty> Faculties = new List<Faculty>();
}

class Department
{
    public string Name;
    public Department(string name)
    {
        Name = name;
    }
}

class Faculty
{
    public string Name;
    public Faculty(string name)
    {
        Name = name;
    }
}
