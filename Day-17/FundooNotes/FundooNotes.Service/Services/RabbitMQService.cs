using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using FundooNotes.Models.DTOs;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConfiguration _configuration;

        public RabbitMQService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task PublishReminderAsync(ReminderMessage reminderMessage)
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

                using var connection = await factory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();

                await channel.QueueDeclareAsync(
                    queue: queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var json = JsonSerializer.Serialize(reminderMessage);
                var body = Encoding.UTF8.GetBytes(json);

                await channel.BasicPublishAsync(
                    exchange: string.Empty,
                    routingKey: queueName,
                    body: body);

                Console.WriteLine($"[RabbitMQ] Published reminder message for Reminder ID {reminderMessage.ReminderId} to queue '{queueName}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[RabbitMQ] Could not publish message to RabbitMQ queue: {ex.Message}. Make sure RabbitMQ URL/Host is properly configured in appsettings.json.");
            }
        }
    }
}
