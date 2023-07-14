namespace HRMS.Core.Models;

public class Department : Base
{
    public string Name { get; set; } = string.Empty;

    public Department? ParentDepartment { get; set; }

    public int Level { get; set; }

    public Employee? Supervisor { get; set; }
}