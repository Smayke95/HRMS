namespace HRMS.SMTP.Interfaces;

public interface IEmailService
{
    Task SendErrorMailAsync(string message);
}