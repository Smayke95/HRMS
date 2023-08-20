using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class TaskTypeInsertUpdate
{
    [Required]
    public string Name { get; set; } = string.Empty;
}