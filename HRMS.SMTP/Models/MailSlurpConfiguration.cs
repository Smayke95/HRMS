namespace HRMS.SMTP.Models;

public class MailSlurpConfiguration
{
    public string ApiKey { get; set; } = string.Empty;

    public string InboxId { get; set; } = string.Empty;

    public string SupportEmails { get; set; } = string.Empty;
}