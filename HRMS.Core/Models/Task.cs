namespace HRMS.Core.Models;

public class Task : Base
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Project Project { get; set; } = new();

    public TaskStatus Status { get; set; } = new();

    public TaskType Type { get; set; } = new();

    public Employee Employee { get; set; } = new();
}