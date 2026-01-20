using System.Collections.Generic;

namespace ResumeScreeningSystem
{
    public class DataScientist : JobRole
    {
        public DataScientist() : base("Data Scientist", new List<string> { "Python", "R", "Machine Learning", "Statistics", "SQL" })
        {
        }
    }
}
