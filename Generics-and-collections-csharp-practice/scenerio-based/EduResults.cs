using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; set; }
    public int Score { get; set; }

    public Student(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public override string ToString() => $"{Name}: {Score}";
}

public class Program
{
    public static List<Student> MergeStudentLists(List<List<Student>> districtLists)
    {
        // Assuming each district list is sorted descending by score (higher score first)
        var result = new List<Student>();
        // PriorityQueue with custom comparer for max-heap (higher score first)
        var pq = new PriorityQueue<(int score, int districtIndex, int studentIndex), (int negScore, int districtIndex, int studentIndex)>();

        // Enqueue the first student from each district
        for (int i = 0; i < districtLists.Count; i++)
        {
            if (districtLists[i].Count > 0)
            {
                int score = districtLists[i][0].Score;
                pq.Enqueue((score, i, 0), (-score, i, 0)); // negScore for max-heap
            }
        }

        while (pq.Count > 0)
        {
            var (score, dIdx, sIdx) = pq.Dequeue();
            result.Add(districtLists[dIdx][sIdx]);

            // If there are more students in this district, enqueue the next one
            if (sIdx + 1 < districtLists[dIdx].Count)
            {
                int nextScore = districtLists[dIdx][sIdx + 1].Score;
                pq.Enqueue((nextScore, dIdx, sIdx + 1), (-nextScore, dIdx, sIdx + 1));
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        // Sample data: Each district submits a sorted list (descending by score)
        var district1 = new List<Student>
        {
            new Student("Alice", 95),
            new Student("Bob", 90),
            new Student("Charlie", 85)
        };

        var district2 = new List<Student>
        {
            new Student("David", 92),
            new Student("Eve", 88),
            new Student("Frank", 80)
        };

        var district3 = new List<Student>
        {
            new Student("Grace", 93),
            new Student("Henry", 87)
        };

        var allDistricts = new List<List<Student>> { district1, district2, district3 };

        // Merge into final rank list
        var finalRankList = MergeStudentLists(allDistricts);

        Console.WriteLine("Final State-wise Rank List:");
        for (int i = 0; i < finalRankList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {finalRankList[i]}");
        }
    }
}
