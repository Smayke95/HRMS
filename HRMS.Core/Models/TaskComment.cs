namespace HRMS.Core.Models;

public class TaskComment
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public virtual Department ParentDepartment { get; set; } = new();

    public int Level { get; set; }

    public virtual Employee Supervisor { get; set; } = new();
}