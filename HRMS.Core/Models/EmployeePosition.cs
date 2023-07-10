using HRMS.Core.Models.Enums;

namespace HRMS.Core.Models;

public class EmployeePosition
{
    public int Id { get; set; }

    public Employee Employee { get; set; } = new();

    public Position Position { get; set; } = new();

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal Salary { get; set; }

    public int VacationDays { get; set; }

    public EmploymentType EmploymentType { get; set; } = new();

    public string WorkingHours { get; set; } = string.Empty;
}