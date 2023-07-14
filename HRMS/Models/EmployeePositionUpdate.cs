using HRMS.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class EmployeePositionUpdate
{
    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public int PositionId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal Salary { get; set; }

    public int VacationDays { get; set; }

    public EmploymentType EmploymentType { get; set; }

    public string WorkingHours { get; set; } = string.Empty;
}