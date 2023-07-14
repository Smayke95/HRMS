namespace HRMS.Core.Models;

public class Task : Base
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public virtual Project Project { get; set; } = new();

    public virtual TaskStatus Status { get; set; } = new();

    public virtual TaskType Type { get; set; } = new();

    public virtual Employee Employee { get; set; } = new();
}