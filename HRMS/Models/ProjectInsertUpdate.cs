using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class ProjectInsertUpdate
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;
}