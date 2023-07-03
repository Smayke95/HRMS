using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace HRMS.Core.Services;

public class EmailService : IEmailService
{
    private readonly SmtpConfiguration SmtpConfiguration;
    private readonly ILogger<EmailService> Logger;

    public EmailService(
        IOptions<SmtpConfiguration> smtpConfiguration,
        ILogger<EmailService> logger)
    {
        SmtpConfiguration = smtpConfiguration.Value;
        Logger = logger;
    }

    public async Task SendErrorMailAsync(string message)
    {
        try
        {
            if (Debugger.IsAttached) return;

            using (var smtpClient = new SmtpClient(SmtpConfiguration.Host, SmtpConfiguration.Port))
            {
                smtpClient.UseDefaultCredentials = SmtpConfiguration.UseDefaultCredentials;
                smtpClient.Credentials = new NetworkCredential(SmtpConfiguration.Username, SmtpConfiguration.Password);
                smtpClient.EnableSsl = SmtpConfiguration.EnableSsl;

                var mail = new MailMessage
                {
                    From = new MailAddress(SmtpConfiguration.Username, "HRMS Support"),
                    Subject = "HRMS Error Message",
                    Body = message,
                    IsBodyHtml = true,
                    Priority = MailPriority.High
                };

                foreach (var address in SmtpConfiguration.SupportEmails.Split(','))
                {
                    mail.To.Add(new MailAddress(address));
                }

                await smtpClient.SendMailAsync(mail);
                Logger.LogInformation("Email sent to " + SmtpConfiguration.SupportEmails + ".");
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Email exception");
        }
    }
}