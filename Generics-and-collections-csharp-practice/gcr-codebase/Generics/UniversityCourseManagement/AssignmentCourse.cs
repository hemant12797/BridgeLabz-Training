using System;

namespace UniversityCourseManagement
{
    public class AssignmentCourse : ICourseType
    {
        public string EvaluationType => "Assignment";

        public void Evaluate()
        {
            Console.WriteLine("Evaluating through assignments.");
        }
    }
}
