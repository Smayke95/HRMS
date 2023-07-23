using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;
using RabbitMQ.Client;
using System.Text;

namespace HRMS.RabbitMQ;

public class NotificationService : INotificationService
{
    public void SendNotification(Notification notification)
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var exchangeName = notification.Group.ToString();
            channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);

            channel.BasicPublish(
                exchange: exchangeName,
                routingKey: string.Empty,
                basicProperties: null,
                body: Encoding.UTF8.GetBytes(notification.ToJson()));
        }
        catch (Exception ex)
        {
            var test = ex;
        }
    }

    public void TakeBreak()
    {
        var notification = new Notification
        {
            Type = NotificationType.Info,
            Group = Role.Employee,
            Text = "Molimo napravite pauzu"
        };

        SendNotification(notification);
    }
}