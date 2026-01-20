namespace UniversityCourseManagement
{
    public interface ICourseType
    {
        string EvaluationType { get; }
        void Evaluate();
    }
}
