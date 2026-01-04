
class Course
{
    public string courseName;
    public int duration;
    public double fee;
    public static string instituteName = "ABC Institute";

    public Course(string name, int duration, double fee)
    {
        courseName = name;
        this.duration = duration;
        this.fee = fee;
    }

    public void DisplayCourseDetails()
    {
        System.Console.WriteLine(courseName + " " + duration + " " + fee + " " + instituteName);
    }

    public static void UpdateInstituteName(string name)
    {
        instituteName = name;
    }
}
