using HRMS.Core.Models.Enums;

namespace HRMS.Core.Models;

public class EmployeeRole
{
    public int Id { get; set; }

    public Employee Employee { get; set; } = new();

    public Role Role { get; set; } = Role.Employee;
}