using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using LabelManagement.Models.DTOs;

namespace LabelManagement.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConfiguration _configuration;

        public RabbitMQService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task PublishReminderAsync(ReminderMessage reminderMessage)
        {
            try
            {
                var factory = new ConnectionFactory();
                var url = _configuration["RabbitMQSettings:Url"];

                if (!string.IsNullOrWhiteSpace(url))
                {
                    factory.Uri = new Uri(url);
                }
                else
                {
                    factory.HostName = _configuration["RabbitMQSettings:HostName"] ?? "localhost";
                    var portStr = _configuration["RabbitMQSettings:Port"];
                    if (int.TryParse(portStr, out int port)) factory.Port = port;
                    factory.UserName = _configuration["RabbitMQSettings:UserName"] ?? "guest";
                    factory.Password = _configuration["RabbitMQSettings:Password"] ?? "guest";
                }

                var queueName = _configuration["RabbitMQSettings:QueueName"] ?? "reminder_queue";

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(
                    queue: queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var json = JsonSerializer.Serialize(reminderMessage);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: queueName,
                    basicProperties: null,
                    body: body);

                Console.WriteLine($"[RabbitMQ] Published reminder for Reminder ID {reminderMessage.ReminderId} to queue '{queueName}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[RabbitMQ] Could not publish: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
