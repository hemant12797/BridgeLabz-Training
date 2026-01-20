using System;

namespace UniversityCourseManagement
{
    public class ExamCourse : ICourseType
    {
        public string EvaluationType => "Exam";

        public void Evaluate()
        {
            Console.WriteLine("Evaluating through written exam.");
        }
    }
}
