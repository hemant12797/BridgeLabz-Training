using System;
using System.Collections.Generic;

using System.Linq;
namespace StudentManagement
{
    public class RecordUtility
    {
        public void AddStudentRecord(string studentName, string subject, int score)
        {
            int nextKey = Program.studentRecords.Count + 1;
            var record = new StudentRecord 
            { 
                StudentName = studentName, 
                Subject = subject, 
                Score = score 
            };
            Program.studentRecords.Add(nextKey, record);
        }
        public SortedDictionary<string, List<StudentRecord>> GroupRecordsBySubject()
        {
            var grouped = Program.studentRecords.Values
                .GroupBy(r => r.Subject)
                .ToDictionary(g => g.Key, g => g.ToList());

            return new SortedDictionary<string, List<StudentRecord>>(grouped);
        }
        public Dictionary<string, double> GetAverageScorePerSubject()
        {
            return Program.studentRecords.Values.GroupBy(r => r.Subject).ToDictionary(g => g.Key, g => g.Average(r => r.Score));
        }        
        public StudentRecord GetTopScorer()
        {
            return Program.studentRecords.Values.OrderByDescending(r => r.Score).FirstOrDefault();
        }
        public List<StudentRecord> FilterStudentsByScore(int minScore)
        {
            return Program.studentRecords.Values.Where(r => r.Score >= minScore).ToList();
        }
    }
}