using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("Departments")]
public class Department
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [ForeignKey("ParentDepartment")]
    public int? ParentDepartmentId { get; set; }
    public virtual Department? ParentDepartment { get; set; }

    public int Level { get; set; }

    [ForeignKey("Supervisor")]
    public int? SupervisorId { get; set; }
    public virtual Employee? Supervisor { get; set; }



    // Relations
    public virtual ICollection<Department> ChildDepartments { get; set; } = new List<Department>();
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}