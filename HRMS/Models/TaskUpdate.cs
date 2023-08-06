namespace HRMS.Models;

public class TaskUpdate
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int? ProjectId { get; set; }

    public int? StatusId { get; set; }

    public int? TypeId { get; set; }

    public int? EmployeeId { get; set; }
}
