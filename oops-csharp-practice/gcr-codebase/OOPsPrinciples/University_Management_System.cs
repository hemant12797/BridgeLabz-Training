
using System.Collections.Generic;

class Student
{
    public string Name;
    public List<Course> Courses = new List<Course>();

    public Student(string name)
    {
        Name = name;
    }

    public void EnrollCourse(Course course)
    {
        Courses.Add(course);
    }
}

class Professor
{
    public string Name;

    public Professor(string name)
    {
        Name = name;
    }

    public void AssignCourse(Course course)
    {
        course.Professor = this;
    }
}

class Course
{
    public string CourseName;
    public Professor Professor;
}
