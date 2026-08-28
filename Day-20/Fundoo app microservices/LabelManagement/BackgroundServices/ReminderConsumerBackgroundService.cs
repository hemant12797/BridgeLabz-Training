using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using LabelManagement.Models.DTOs;
using LabelManagement.Services;

namespace LabelManagement.BackgroundServices
{
    public class ReminderConsumerBackgroundService : BackgroundService
    {
        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;

        public ReminderConsumerBackgroundService(IConfiguration config, IServiceProvider serviceProvider)
        {
            _config = config;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var factory = new ConnectionFactory();
                var url = _config["RabbitMQSettings:Url"];
                if (!string.IsNullOrEmpty(url)) factory.Uri = new Uri(url);
                else factory.HostName = _config["RabbitMQSettings:HostName"] ?? "localhost";

                // v6.x synchronous connection
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                channel.QueueDeclare("reminder_queue", durable: true, exclusive: false, autoDelete: false);

                // v6.x event-based consumer
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var msg = JsonSerializer.Deserialize<ReminderMessage>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                    if (msg == null || string.IsNullOrEmpty(msg.Email)) return;

                    DateTime targetTime = msg.ReminderTime.Kind == DateTimeKind.Utc
                        ? msg.ReminderTime.ToLocalTime()
                        : msg.ReminderTime;

                    var delay = targetTime - DateTime.Now;
                    if (delay > TimeSpan.Zero)
                    {
                        Console.WriteLine($"[RabbitMQ Consumer] Delaying email for '{msg.NoteTitle}' to '{msg.Email}' until {targetTime:g} (waiting {delay.TotalSeconds:F0}s)...");
                        await Task.Delay(delay, stoppingToken);
                    }

                    Console.WriteLine($"[RabbitMQ Consumer] Dispatching email for note '{msg.NoteTitle}' to '{msg.Email}'...");

                    using var scope = _serviceProvider.CreateScope();
                    var smtp = scope.ServiceProvider.GetRequiredService<ISmtpService>();
                    await smtp.SendEmailAsync(
                        msg.Email,
                        $"Reminder: {msg.NoteTitle}",
                        $"Hello,<br/><br/>This is your scheduled reminder for note: <strong>{msg.NoteTitle}</strong> set for {targetTime:g}.");
                };

                channel.BasicConsume("reminder_queue", autoAck: true, consumer: consumer);

                // Keep the background service alive
                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[RabbitMQ Error] {ex.Message}");
            }
        }
    }
}
