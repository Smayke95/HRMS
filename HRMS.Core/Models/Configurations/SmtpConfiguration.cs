namespace HRMS.Core.Models.Configurations;

public class SmtpConfiguration
{
    public string Host { get; set; } = string.Empty;

    public int Port { get; set; }

    public bool UseDefaultCredentials { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool EnableSsl { get; set; }

    public string SupportEmails { get; set; } = string.Empty;
}