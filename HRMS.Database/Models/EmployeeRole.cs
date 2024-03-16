using HRMS.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("EmployeeRoles")]
public class EmployeeRole
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }

    public Role Role { get; set; } = Role.Employee;
}