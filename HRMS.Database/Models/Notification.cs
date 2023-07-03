using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("Notifications")]
public class Notification
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }

    public string Text { get; set; } = string.Empty;

    public bool IsReaded { get; set; }
}