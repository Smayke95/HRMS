namespace HRMS.Core.Interfaces.Services;

public interface IEmailService
{
    Task SendErrorMailAsync(string message);
}