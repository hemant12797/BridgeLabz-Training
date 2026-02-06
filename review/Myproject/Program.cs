using System;
using System.Collections.Generic;

namespace StudentManagement
{
    class Program
    {
        public static SortedDictionary<int, StudentRecord> studentRecords = new SortedDictionary<int, StudentRecord>();
        
        static void Main(string[] args)
        {
            RecordUtility utility = new RecordUtility();
            bool running = true;

            while (running)
            {
                Console.WriteLine("--- Student Record Management ---");
                Console.WriteLine("1. Add Student Record");
                Console.WriteLine("2. Group Records By Subject");
                Console.WriteLine("3. Show Average Score Per Subject");
                Console.WriteLine("4. Show Top Scorer");
                Console.WriteLine("5. Filter Students By Min Score");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter Name: "); 
                        string name = Console.ReadLine();
                        Console.Write("Enter Subject: "); 
                        string sub = Console.ReadLine();
                        Console.Write("Enter Score: "); 
                        int score = int.Parse(Console.ReadLine());
                        utility.AddStudentRecord(name, sub, score);
                        break;

                    case "2":
                        var groups = utility.GroupRecordsBySubject();
                        foreach (var group in groups)
                        {
                            Console.WriteLine($"\nSubject: {group.Key}");
                            group.Value.ForEach(r => Console.WriteLine($" - {r.StudentName}: {r.Score}"));
                        }
                        break;

                    case "3":
                        var averages = utility.GetAverageScorePerSubject();
                        foreach (var avg in averages) 
                            Console.WriteLine($"{avg.Key}: {avg.Value:F2}");
                        break;

                    case "4":
                        var top = utility.GetTopScorer();
                        Console.WriteLine(top != null ? $"Top Scorer: {top}" : "No records found.");
                        break;

                    case "5":
                        Console.Write("Enter Min Score: ");
                        int min = int.Parse(Console.ReadLine());
                        var filtered = utility.FilterStudentsByScore(min);
                        filtered.ForEach(Console.WriteLine);
                        break;

                    case "6":
                        Console.WriteLine("Thankyou");
                        running = false;
                        break;
                }
            }
        }
    }
}