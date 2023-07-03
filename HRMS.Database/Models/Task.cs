using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("Tasks")]
public class Task
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [ForeignKey("Project")]
    public int? ProjectId { get; set; }
    public virtual Project? Project { get; set; }

    [ForeignKey("TaskStatus")]
    public int? TaskStatusId { get; set; }
    public virtual TaskStatus? Status { get; set; }

    [ForeignKey("TaskType")]
    public int? TaskTypeId { get; set; }
    public virtual TaskType? Type { get; set; }

    [ForeignKey("Employee")]
    public int? EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }



    // Relations
    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();
}