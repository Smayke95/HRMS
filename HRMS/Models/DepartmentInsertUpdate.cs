using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class DepartmentInsertUpdate
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int? ParentDepartmentId { get; set; }

    [Required]
    public int Level { get; set; }

    public int? SupervisorId { get; set; }
}