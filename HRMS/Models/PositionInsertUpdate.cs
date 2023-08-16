using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class PositionInsertUpdate
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int? DepartmentId { get; set; }

    [Required]
    public int? PayGradeId { get; set; }

    [Required]
    public int? RequiredEducationId { get; set; }

    public bool IsWorkExperienceRequired { get; set; }
}