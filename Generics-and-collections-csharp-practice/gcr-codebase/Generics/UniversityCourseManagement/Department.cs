using System;
using System.Collections.Generic;

namespace UniversityCourseManagement
{
    public class Department
    {
        public string Name { get; set; }
        public List<ICourse> Courses { get; set; } = new List<ICourse>();

        public Department(string name)
        {
            Name = name;
        }

        public void AddCourse(ICourse course)
        {
            Courses.Add(course);
        }

        public void DisplayCourses()
        {
            Console.WriteLine($"Courses in {Name} Department:");
            foreach (var course in Courses)
            {
                course.DisplayInfo();
            }
        }
    }
}
