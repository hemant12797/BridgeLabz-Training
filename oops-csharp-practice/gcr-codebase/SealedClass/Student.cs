
class Student
{
    public static string UniversityName = "ABC University";
    private static int totalStudents = 0;

    public string Name;
    public readonly int RollNumber;
    public char Grade;

    public Student(string name, int roll, char grade)
    {
        this.Name = name;
        this.RollNumber = roll;
        this.Grade = grade;
        totalStudents++;
    }

    public static void DisplayTotalStudents()
    {
        System.Console.WriteLine("Total Students: " + totalStudents);
    }

    public void Show(object obj)
    {
        if (obj is Student)
            System.Console.WriteLine(Name + " " + RollNumber + " " + Grade);
    }
}
