
class Employee
{
    public string Name;
    public int Id;
    public double Salary;

    public virtual void DisplayDetails()
    {
        System.Console.WriteLine(Name + " " + Id + " " + Salary);
    }
}

class Manager : Employee
{
    public int TeamSize;
    public override void DisplayDetails()
    {
        System.Console.WriteLine(Name + " " + Id + " " + Salary + " TeamSize:" + TeamSize);
    }
}

class Developer : Employee
{
    public string ProgrammingLanguage;
    public override void DisplayDetails()
    {
        System.Console.WriteLine(Name + " " + Id + " " + Salary + " Lang:" + ProgrammingLanguage);
    }
}

class Intern : Employee
{
    public string InternshipDuration;
    public override void DisplayDetails()
    {
        System.Console.WriteLine(Name + " " + Id + " " + Salary + " Duration:" + InternshipDuration);
    }
}
