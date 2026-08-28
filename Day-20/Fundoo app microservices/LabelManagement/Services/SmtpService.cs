using System.Net;
using System.Net.Mail;

namespace LabelManagement.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly IConfiguration _configuration;

        public SmtpService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var host = _configuration["SmtpSettings:Host"];
            var portStr = _configuration["SmtpSettings:Port"];
            var username = _configuration["SmtpSettings:Username"];
            var password = _configuration["SmtpSettings:Password"];
            var fromEmail = _configuration["SmtpSettings:FromEmail"] ?? "no-reply@fundoonotes.com";
            var enableSslStr = _configuration["SmtpSettings:EnableSsl"];

            if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(toEmail))
            {
                Console.WriteLine($"[SMTP] Email dispatch skipped for '{toEmail}': SMTP settings not configured.");
                return;
            }

            int port = int.TryParse(portStr, out var p) ? p : 587;
            bool enableSsl = !bool.TryParse(enableSslStr, out var ssl) || ssl;

            using var smtpClient = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = enableSsl
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
            Console.WriteLine($"[SMTP] Successfully sent reminder email to {toEmail}");
        }
    }
}
