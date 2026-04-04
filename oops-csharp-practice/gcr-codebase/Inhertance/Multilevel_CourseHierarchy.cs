
class Course
{
    public string CourseName;
    public int Duration;
}

class OnlineCourse : Course
{
    public string Platform;
    public bool IsRecorded;
}

class PaidOnlineCourse : OnlineCourse
{
    public double Fee;
    public double Discount;
}
