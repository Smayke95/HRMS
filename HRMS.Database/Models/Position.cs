using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("Positions")]
public class Position
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public virtual Department? Department { get; set; }

    [ForeignKey("PayGrade")]
    public int PayGradeId { get; set; }
    public virtual PayGrade? PayGrade { get; set; }

    [ForeignKey("RequiredEducation")]
    public int RequiredEducationId { get; set; }
    public virtual Education? RequiredEducation { get; set; }

    public bool IsWorkExperienceRequired { get; set; }



    // Relations
    public virtual ICollection<EmployeePosition> EmployeePositions { get; set; } = new List<EmployeePosition>();
}