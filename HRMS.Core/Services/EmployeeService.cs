using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.Services;

public class EmployeeService(
    IEmployeeRepository employeeRepository,
    INotificationService notificationService)
    : IEmployeeService
{
    private readonly IEmployeeRepository EmployeeRepository = employeeRepository;
    private readonly INotificationService NotificationService = notificationService;

    public async Task<Employee> InsertAsync(Employee employee)
    {
        var insertedEmployee = await EmployeeRepository.InsertAsync(employee);

        var notification = new Notification
        {
            Type = NotificationType.Info,
            Group = Role.Manager,
            Text = $"{insertedEmployee.FirstName} {insertedEmployee.LastName} je dodan kao novi zaposlenik."
        };

        NotificationService.SendNotification(notification);

        return insertedEmployee;
    }
}