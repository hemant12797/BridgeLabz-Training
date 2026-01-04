
using System.Collections.Generic;

class School
{
    public List<Student> Students = new List<Student>();
}

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
        course.Students.Add(this);
    }
}

class Course
{
    public string CourseName;
    public List<Student> Students = new List<Student>();

    public Course(string name)
    {
        CourseName = name;
    }
}
