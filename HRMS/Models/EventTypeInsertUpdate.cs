using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class EventTypeInsertUpdate
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public bool IsApprovalRequired { get; set; } = true;

    public string? Color { get; set; } = string.Empty;
}