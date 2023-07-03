using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("Messages")]
public class Message
{
    [Key]
    public int Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public DateTime Time { get; set; } = new DateTime();

    public string Room { get; set; } = string.Empty;

    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
}