using System;
using System.Collections.Generic;

public class CallLog
{
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }

    public CallLog(string phoneNumber, string message, DateTime timestamp)
    {
        PhoneNumber = phoneNumber;
        Message = message;
        Timestamp = timestamp;
    }
}

public class CallLogManager
{
    private List<CallLog> logs;

    public CallLogManager()
    {
        logs = new List<CallLog>();
    }

    public void AddCallLog(CallLog log)
    {
        logs.Add(log);
    }

    public List<CallLog> SearchByKeyword(string keyword)
    {
        List<CallLog> results = new List<CallLog>();
        foreach (var log in logs)
        {
            if (log.Message.Contains(keyword))
            {
                results.Add(log);
            }
        }
        return results;
    }

    public List<CallLog> FilterByTime(DateTime start, DateTime end)
    {
        List<CallLog> results = new List<CallLog>();
        foreach (var log in logs)
        {
            if (log.Timestamp >= start && log.Timestamp <= end)
            {
                results.Add(log);
            }
        }
        return results;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CallLogManager manager = new CallLogManager();

        manager.AddCallLog(new CallLog("123-456-7890", "Complaint about billing", DateTime.Now.AddHours(-2)));
        manager.AddCallLog(new CallLog("098-765-4321", "Inquiry on service", DateTime.Now.AddHours(-1)));
        manager.AddCallLog(new CallLog("555-123-4567", "Billing issue resolved", DateTime.Now));

        var keywordResults = manager.SearchByKeyword("billing");
        Console.WriteLine("Search by 'billing':");
        foreach (var log in keywordResults)
        {
            Console.WriteLine($"{log.PhoneNumber}: {log.Message} at {log.Timestamp}");
        }

        var timeResults = manager.FilterByTime(DateTime.Now.AddHours(-3), DateTime.Now);
        Console.WriteLine("\nFilter by last 3 hours:");
        foreach (var log in timeResults)
        {
            Console.WriteLine($"{log.PhoneNumber}: {log.Message} at {log.Timestamp}");
        }
    }
}
