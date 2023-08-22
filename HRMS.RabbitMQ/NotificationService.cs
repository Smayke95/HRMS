using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;

namespace HRMS.RabbitMQ;

public class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> Logger;

    public NotificationService(ILogger<NotificationService> logger)
    {
        Logger = logger;
    }

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
            Logger.LogError(ex, "Send Notification exception");
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