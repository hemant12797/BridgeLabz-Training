using System;
using System.Collections.Generic;

public class VotingSystem
{
    private Dictionary<string, int> votes = new Dictionary<string, int>();
    private List<string> order = new List<string>();

    public void Vote(string candidate)
    {
        if (!votes.ContainsKey(candidate))
        {
            order.Add(candidate);
            votes[candidate] = 0;
        }
        votes[candidate]++;
    }

    public void DisplayResults()
    {
        Console.WriteLine("Voting Results (in order of appearance):");
        foreach (var candidate in order)
        {
            Console.WriteLine($"{candidate}: {votes[candidate]} votes");
        }

        Console.WriteLine("\nVoting Results (sorted alphabetically):");
        var sortedResults = new SortedDictionary<string, int>(votes);
        foreach (var kvp in sortedResults)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} votes");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        VotingSystem system = new VotingSystem();

        // Sample votes
        system.Vote("Alice");
        system.Vote("Bob");
        system.Vote("Alice");
        system.Vote("Charlie");
        system.Vote("Bob");
        system.Vote("Alice");

        system.DisplayResults();
    }
}
