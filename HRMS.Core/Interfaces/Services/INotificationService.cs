using HRMS.Core.Models;

namespace HRMS.Core.Interfaces.Services;

public interface INotificationService
{
    void SendNotification(Notification notification);
    void TakeBreak();
}