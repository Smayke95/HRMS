namespace HRMS.Core.Models;

public class TaskComment : Base
{
    public DateTime Time { get; set; }

    public string Content { get; set; } = string.Empty;

    public Task Task { get; set; } = new();

    public Employee Employee { get; set; } = new();
}