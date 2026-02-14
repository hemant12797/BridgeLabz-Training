using NotifyHub.Models;

namespace NotifyHub.Models
{
    public class EmailNotification : Notification
    {
        public override string Type => "Email";
    }
}
