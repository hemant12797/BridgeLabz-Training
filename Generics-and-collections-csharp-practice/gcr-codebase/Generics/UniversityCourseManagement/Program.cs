using System;
using System.Collections.Generic;

namespace UniversityCourseManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create departments
            Department csDept = new Department("Computer Science");
            Department mathDept = new Department("Mathematics");

            // Create courses with different evaluation types
            var csCourse1 = new Course<ExamCourse>("Data Structures", "Computer Science", new ExamCourse());
            var csCourse2 = new Course<AssignmentCourse>("Software Engineering", "Computer Science", new AssignmentCourse());
            var mathCourse1 = new Course<ExamCourse>("Calculus", "Mathematics", new ExamCourse());
            var mathCourse2 = new Course<AssignmentCourse>("Statistics", "Mathematics", new AssignmentCourse());

            // Add courses to departments
            csDept.AddCourse(csCourse1);
            csDept.AddCourse(csCourse2);
            mathDept.AddCourse(mathCourse1);
            mathDept.AddCourse(mathCourse2);

            // Display courses
            csDept.DisplayCourses();
            Console.WriteLine();
            mathDept.DisplayCourses();

            // Demonstrate handling any type of course dynamically using List<ICourse>
            List<ICourse> allCourses = new List<ICourse>();
            allCourses.AddRange(csDept.Courses);
            allCourses.AddRange(mathDept.Courses);

            Console.WriteLine("\nAll Courses:");
            foreach (var course in allCourses)
            {
                course.DisplayInfo();
            }
        }
    }
}
