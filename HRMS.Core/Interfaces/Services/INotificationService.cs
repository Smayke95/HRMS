using HRMS.Core.Models;
using Task = System.Threading.Tasks.Task;

namespace HRMS.Core.Interfaces.Services;

public interface INotificationService
{
    Task SendNotification(Notification notification);
}