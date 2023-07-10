namespace HRMS.Core.Models;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Department? ParentDepartment { get; set; }

    public int Level { get; set; }

    public Employee? Supervisor { get; set; }
}