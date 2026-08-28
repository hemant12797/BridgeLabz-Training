namespace FundooNotes.Service.Interface
{
    public interface ISmtpService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
