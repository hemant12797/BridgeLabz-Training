using System;
using NotifyHub.Attributes;

namespace NotifyHub.Models
{
    public abstract class Notification
    {
        [Required]
        public string NotificationId { get; set; } = string.Empty;

        [Required]
        public string Recipient { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public NotificationPriority Priority { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Pending";

        public abstract string Type { get; }
    }
}
