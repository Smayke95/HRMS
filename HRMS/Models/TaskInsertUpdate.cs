using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class TaskInsertUpdate
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required]
    public int? ProjectId { get; set; }

    [Required]
    public int? StatusId { get; set; }

    [Required]
    public int? TypeId { get; set; }

    [Required]
    public int? EmployeeId { get; set; }
}