using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class TaskCommentInsertUpdate
{
    [Required]
    public DateTime Time { get; set; }

    [Required]
    public string Content { get; set; } = string.Empty;

    [Required]
    public int? TaskId { get; set; }

    [Required]
    public int? EmployeeId { get; set; }
}