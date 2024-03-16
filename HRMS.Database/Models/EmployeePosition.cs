using HRMS.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("EmployeePositions")]
public class EmployeePosition
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }
    public virtual Position? Position { get; set; }

    [DataType(DataType.Date)]
    [Column(TypeName = "Date")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    [Column(TypeName = "Date")]
    public DateTime? EndDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }

    public int VacationDays { get; set; }

    public EmploymentType Type { get; set; }

    public EmploymentStatus Status { get; set; }

    public string WorkingHours { get; set; } = string.Empty;
}