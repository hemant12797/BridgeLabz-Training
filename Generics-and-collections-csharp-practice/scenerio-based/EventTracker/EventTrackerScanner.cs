using EventTracker.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace EventTracker
{
    public class AuditEvent
    {
        public string? EventType { get; set; }
        public string? ClassName { get; set; }
        public string? MethodName { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Metadata { get; set; }
    }

    public class EventTrackerScanner
    {
        public void ScanAndGenerateLogs()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var serviceTypes = assembly.GetTypes()
                .Where(t => t.Namespace != null && t.Namespace.Contains("Services") && t.IsClass);

            var auditEvents = new List<AuditEvent>();

            foreach (var serviceType in serviceTypes)
            {
                var methods = serviceType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (var method in methods)
                {
                    var auditAttr = method.GetCustomAttribute<AuditTrailAttribute>();
                    if (auditAttr != null)
                    {
                        var auditEvent = new AuditEvent
                        {
                            EventType = auditAttr.EventType,
                            ClassName = serviceType.Name,
                            MethodName = method.Name,
                            Timestamp = DateTime.UtcNow,
                            Metadata = $"Method: {method.Name}, Class: {serviceType.Name}"
                        };
                        auditEvents.Add(auditEvent);
                    }
                }
            }

            Console.WriteLine("=== Auto Audit System - JSON Logs ===");
            foreach (var auditEvent in auditEvents)
            {
                string json = JsonSerializer.Serialize(auditEvent, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(json);
                Console.WriteLine();
            }
        }
    }
}
