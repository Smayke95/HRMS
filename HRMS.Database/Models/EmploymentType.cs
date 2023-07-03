using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("EmploymentTypes")]
public class EmploymentType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;



    // Relations
    public virtual ICollection<EmployeePosition> EmployeePositions { get; set; } = new List<EmployeePosition>();
}