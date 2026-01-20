using System;

namespace UniversityCourseManagement
{
    public class Course<T> : ICourse where T : ICourseType
    {
        public string CourseName { get; set; }
        public string Department { get; set; }
        public T CourseType { get; set; }

        public Course(string courseName, string department, T courseType)
        {
            CourseName = courseName;
            Department = department;
            CourseType = courseType;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Course: {CourseName}, Department: {Department}, Evaluation: {CourseType.EvaluationType}");
            CourseType.Evaluate();
        }
    }
}
