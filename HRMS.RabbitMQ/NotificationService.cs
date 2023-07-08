using HRMS.Core.Interfaces.Services;
using RabbitMQ.Client;
using System.Text;

namespace HRMS.RabbitMQ;

public class NotificationService : INotificationService
{
    public void SendNotification()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "product_added",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        channel.BasicPublish(
            exchange: string.Empty,
            routingKey: "hello",
            basicProperties: null,
            body: Encoding.UTF8.GetBytes("Hello World Anes!"));
    }
}