using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using Task = System.Threading.Tasks.Task;

namespace HRMS.RabbitMQ;

public class EmailService : IEmailService
{
    private readonly RabbitMQConfiguration RabbitMQConfiguration;
    private readonly ILogger<EmailService> Logger;

    public EmailService(
        IOptions<RabbitMQConfiguration> rabbitMQConfiguration,
        ILogger<EmailService> logger)
    {
        RabbitMQConfiguration = rabbitMQConfiguration.Value;
        Logger = logger;
    }

    public Task SendErrorMailAsync(string message)
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = RabbitMQConfiguration.Host,
                Port = RabbitMQConfiguration.Port,
                UserName = RabbitMQConfiguration.User,
                Password = RabbitMQConfiguration.Password
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare("Email", ExchangeType.Fanout);

            channel.BasicPublish(
                exchange: "Email",
                routingKey: string.Empty,
                basicProperties: null,
                body: Encoding.UTF8.GetBytes(message)
            );
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "SendErrorMailAsync");
        }

        return Task.CompletedTask;
    }
}