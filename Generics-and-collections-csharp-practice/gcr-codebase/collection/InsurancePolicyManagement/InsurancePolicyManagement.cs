using System;
using System.Collections.Generic;
using System.Linq;

public class Policy
{
    public string PolicyNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string CoverageType { get; set; }

    public Policy(string policyNumber, DateTime expiryDate, string coverageType)
    {
        PolicyNumber = policyNumber;
        ExpiryDate = expiryDate;
        CoverageType = coverageType;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Policy other)
        {
            return PolicyNumber == other.PolicyNumber;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return PolicyNumber.GetHashCode();
    }

    public override string ToString()
    {
        return $"PolicyNumber: {PolicyNumber}, ExpiryDate: {ExpiryDate.ToString("yyyy-MM-dd")}, CoverageType: {CoverageType}";
    }
}

public class PolicyExpiryComparer : IComparer<Policy>
{
    public int Compare(Policy? x, Policy? y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return x.ExpiryDate.CompareTo(y.ExpiryDate);
    }
}

public class InsurancePolicyManagementSystem
{
    private List<Policy> allPolicies = new List<Policy>();
    private HashSet<Policy> uniquePolicies = new HashSet<Policy>();
    private List<Policy> insertionOrder = new List<Policy>();
    private SortedSet<Policy> sortedByExpiry = new SortedSet<Policy>(new PolicyExpiryComparer());

    public void AddPolicy(Policy policy)
    {
        allPolicies.Add(policy);
        if (uniquePolicies.Add(policy))
        {
            insertionOrder.Add(policy);
            sortedByExpiry.Add(policy);
        }
    }

    public IEnumerable<Policy> GetAllUniquePolicies()
    {
        return uniquePolicies;
    }

    public IEnumerable<Policy> GetPoliciesExpiringSoon()
    {
        DateTime soon = DateTime.Now.AddDays(30);
        return uniquePolicies.Where(p => p.ExpiryDate <= soon);
    }

    public IEnumerable<Policy> GetPoliciesByCoverageType(string coverageType)
    {
        return uniquePolicies.Where(p => p.CoverageType.Equals(coverageType, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<IGrouping<string, Policy>> GetDuplicatePolicies()
    {
        return allPolicies.GroupBy(p => p.PolicyNumber).Where(g => g.Count() > 1);
    }

    public IEnumerable<Policy> GetInsertionOrderPolicies()
    {
        return insertionOrder;
    }

    public IEnumerable<Policy> GetSortedByExpiryPolicies()
    {
        return sortedByExpiry;
    }
}

public partial class Program
{
    public static void Main(string[] args)
    {
        InsurancePolicyManagementSystem system = new InsurancePolicyManagementSystem();

        // Sample data
        system.AddPolicy(new Policy("P001", DateTime.Now.AddDays(10), "Health"));
        system.AddPolicy(new Policy("P002", DateTime.Now.AddDays(50), "Auto"));
        system.AddPolicy(new Policy("P001", DateTime.Now.AddDays(20), "Health")); // Duplicate
        system.AddPolicy(new Policy("P003", DateTime.Now.AddDays(5), "Life"));
        system.AddPolicy(new Policy("P004", DateTime.Now.AddDays(25), "Auto"));

        Console.WriteLine("All Unique Policies:");
        foreach (var policy in system.GetAllUniquePolicies())
        {
            Console.WriteLine(policy);
        }

        Console.WriteLine("\nPolicies Expiring Soon (within 30 days):");
        foreach (var policy in system.GetPoliciesExpiringSoon())
        {
            Console.WriteLine(policy);
        }

        Console.WriteLine("\nPolicies with Coverage Type 'Auto':");
        foreach (var policy in system.GetPoliciesByCoverageType("Auto"))
        {
            Console.WriteLine(policy);
        }

        Console.WriteLine("\nDuplicate Policies (grouped by PolicyNumber):");
        foreach (var group in system.GetDuplicatePolicies())
        {
            Console.WriteLine($"PolicyNumber: {group.Key}");
            foreach (var policy in group)
            {
                Console.WriteLine($"  {policy}");
            }
        }

        Console.WriteLine("\nInsertion Order:");
        foreach (var policy in system.GetInsertionOrderPolicies())
        {
            Console.WriteLine(policy);
        }

        Console.WriteLine("\nSorted by Expiry Date:");
        foreach (var policy in system.GetSortedByExpiryPolicies())
        {
            Console.WriteLine(policy);
        }
    }
}
