namespace HRMS.Models;

public class DepartmentUpdate
{
    public string Name { get; set; } = string.Empty;

    public int? ParentDepartmentId { get; set; }

    public int Level { get; set; }

    public int? SupervisorId { get; set; }
}