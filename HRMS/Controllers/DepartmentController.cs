using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Requests;
using HRMS.Core.Models.Searches;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class DepartmentController : BaseController<Department, DepartmentSearch>
{
    private readonly INotificationService NotificationService;

    public DepartmentController(
        IDepartmentRepository departmentRepository,
        INotificationService notificationService
        ) : base(departmentRepository)
    {
        NotificationService = notificationService;
    }

    [HttpPost]
    public void Insert([FromBody] DepartmentInsertRequest department)
        => NotificationService.SendNotification();
}