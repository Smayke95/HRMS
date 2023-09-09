using HRMS.SMTP.Interfaces;
using HRMS.SMTP.Models;
using mailslurp.Api;
using mailslurp.Client;
using mailslurp.Model;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;

namespace HRMS.SMTP.Services;

public class EmailService : IEmailService
{
    private readonly RabbitMQConfiguration RabbitMQConfiguration;
    private readonly MailSlurpConfiguration MailSlurpConfiguration;
    private readonly ILogger<EmailService> Logger;
    private IConnection? Connection;
    private IModel? Channel;

    public EmailService(
        IOptions<RabbitMQConfiguration> rabbitMQConfiguration,
        IOptions<MailSlurpConfiguration> mailSlurpConfiguration,
        ILogger<EmailService> logger)
    {
        RabbitMQConfiguration = rabbitMQConfiguration.Value;
        MailSlurpConfiguration = mailSlurpConfiguration.Value;
        Logger = logger;

        Connect();
    }

    private void Connect()
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = RabbitMQConfiguration.Host,
                Port = RabbitMQConfiguration.Port,
                UserName = RabbitMQConfiguration.User,
                Password = RabbitMQConfiguration.Password,
                DispatchConsumersAsync = true
            };

            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();

            Channel.ExchangeDeclare("Email", ExchangeType.Fanout);

            var queueName = Channel
                .QueueDeclare(
                    durable: true,
                    exclusive: false,
                    autoDelete: false)
                .QueueName;

            Channel.QueueBind(
                queue: queueName,
                exchange: "Email",
                routingKey: string.Empty
            );

            var consumer = new AsyncEventingBasicConsumer(Channel);
            consumer.Received += SendErrorMailEventHandler;

            Channel.BasicConsume(
                queue: queueName,
                autoAck: true,
                consumer: consumer
            );
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "EmailService");
        }
    }

    private async Task SendErrorMailEventHandler(object? model, BasicDeliverEventArgs eventArgs)
    {
        if (Debugger.IsAttached) return;

        var body = eventArgs.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        await SendErrorMailAsync(message);
    }

    public async Task SendErrorMailAsync(string message)
    {
        try
        {
            var configuration = new Configuration();
            configuration.ApiKey.Add("x-api-key", MailSlurpConfiguration.ApiKey);

            var inboxController = new InboxControllerApi(configuration);

            var sendEmailOptions = new SendEmailOptions
            {
                UseInboxName = true,
                Subject = "HRMS Error Message",
                Body = message,
                IsHTML = true,
                To = MailSlurpConfiguration
                    .SupportEmails
                    .Split(',')
                    .ToList()
            };

            await inboxController.SendEmailAndConfirmAsync(Guid.Parse(MailSlurpConfiguration.InboxId), sendEmailOptions);
            Logger.LogInformation("Email sent to " + MailSlurpConfiguration.SupportEmails + ".");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Send Error Mail exception");
        }
    }
}