namespace HRMS.Models;

public class TaskUpdate
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int? ProjectId { get; set; }

    public int? TaskStatusId { get; set; }

    public int? TaskTypeId { get; set; }

    public int? EmployeeId { get; set; }
}
