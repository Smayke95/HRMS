using HRMS.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class EmployeePositionInsertUpdate
{
    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public int PositionId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    public decimal Salary { get; set; }

    [Required]
    public int VacationDays { get; set; }

    [Required]
    public EmploymentType EmploymentType { get; set; }

    public string WorkingHours { get; set; } = string.Empty;
}