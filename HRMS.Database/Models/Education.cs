using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("Educations")]
public class Education
{
    [Key]
    public int Id { get; set; }

    public string ISCED { get; set; } = string.Empty;

    public int EQF { get; set; }

    public string Qualification { get; set; } = string.Empty;

    public string FinishedEducation { get; set; } = string.Empty;

    public string QualificationOld { get; set; } = string.Empty;

    public string FinishedEducationOld { get; set; } = string.Empty;



    // Relations
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}