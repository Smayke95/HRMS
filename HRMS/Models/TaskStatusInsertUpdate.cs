using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class TaskStatusInsertUpdate
{
    [Required]
    public string Name { get; set; } = string.Empty;
}