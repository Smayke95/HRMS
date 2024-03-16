using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("TaskComments")]
public class TaskComment
{
    [Key]
    public int Id { get; set; }

    public DateTime Time { get; set; }

    public string Content { get; set; } = string.Empty;

    [ForeignKey(nameof(Task))]
    public int TaskId { get; set; }
    public virtual Task? Task { get; set; }

    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
}