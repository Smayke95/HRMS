using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class EventInsertUpdate
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    [Required]
    public int? EventTypeId { get; set; }

    [Required]
    public int? EmployeeId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
}