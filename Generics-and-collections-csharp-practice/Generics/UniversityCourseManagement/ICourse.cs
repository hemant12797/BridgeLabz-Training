namespace UniversityCourseManagement
{
    public interface ICourse
    {
        string CourseName { get; }
        string Department { get; }
        void DisplayInfo();
    }
}
