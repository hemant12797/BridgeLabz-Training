using System;

namespace EventTracker.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuditTrailAttribute : Attribute
    {
        public string EventType { get; set; }

        public AuditTrailAttribute(string eventType)
        {
            EventType = eventType;
        }
    }
}
