using System.Collections.Generic;

namespace ResumeScreeningSystem
{
    public class ScreeningPipeline<T> where T : JobRole, new()
    {
        private List<Resume<T>> Resumes { get; set; }

        public ScreeningPipeline()
        {
            Resumes = new List<Resume<T>>();
        }

        public void AddResume(Resume<T> resume)
        {
            Resumes.Add(resume);
        }

        public void ScreenResumes()
        {
            Console.WriteLine($"Screening resumes for {new T().RoleName}:");
            foreach (var resume in Resumes)
            {
                resume.DisplayResume();
                Console.WriteLine();
            }
        }

        public List<Resume<T>> GetQualifiedResumes()
        {
            return Resumes.FindAll(r => r.IsQualified());
        }
    }
}
