using NotifyHub.Models;

namespace NotifyHub.Models
{
    public class SmsNotification : Notification
    {
        public override string Type => "SMS";
    }
}
