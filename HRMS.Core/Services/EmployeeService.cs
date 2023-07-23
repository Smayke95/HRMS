using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository EmployeeRepository;
    private readonly INotificationService NotificationService;

    public EmployeeService(
        IEmployeeRepository employeeRepository,
        INotificationService notificationService)
    {
        EmployeeRepository = employeeRepository;
        NotificationService = notificationService;
    }

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