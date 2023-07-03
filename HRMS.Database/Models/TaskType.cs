using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("TaskTypes")]
public class TaskType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;



    // Relations
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}