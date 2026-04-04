
class Person
{
    public string Name;
    public int Age;
}

class Teacher : Person
{
    public string Subject;
    public void DisplayRole()
    {
        System.Console.WriteLine("Teacher");
    }
}

class Student : Person
{
    public string Grade;
    public void DisplayRole()
    {
        System.Console.WriteLine("Student");
    }
}

class Staff : Person
{
    public string Department;
    public void DisplayRole()
    {
        System.Console.WriteLine("Staff");
    }
}
