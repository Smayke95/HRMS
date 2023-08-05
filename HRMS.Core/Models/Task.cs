namespace HRMS.Core.Models;

public class Task : Base
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Project? Project { get; set; }

    public TaskStatus? Status { get; set; }

    public TaskType? Type { get; set; }

    public Employee? Employee { get; set; }
}