
class Student
{
    public int rollNumber;
    protected string name;
    private double CGPA;

    public void SetCGPA(double cgpa)
    {
        CGPA = cgpa;
    }

    public double GetCGPA()
    {
        return CGPA;
    }
}

class PostgraduateStudent : Student
{
    public void ShowName()
    {
        System.Console.WriteLine(name);
    }
}
