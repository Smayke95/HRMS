using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using RabbitMQ.Client;
using System.Text;
using Task = System.Threading.Tasks.Task;

namespace HRMS.RabbitMQ;

public class NotificationService : INotificationService
{
    public async Task SendNotification(Notification notification)
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
}