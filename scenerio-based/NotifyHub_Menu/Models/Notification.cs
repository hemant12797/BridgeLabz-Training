
using System;

namespace NotifyHub.Models
{
    public enum Priority { Low=1, Medium=2, High=3 }

    public class Notification
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Type { get; set; } = "";
        public string Recipient { get; set; } = "";
        public string Message { get; set; } = "";
        public Priority Priority { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
