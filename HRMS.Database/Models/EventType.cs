using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("EventTypes")]
public class EventType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsApprovalRequired { get; set; }

    public string Color { get; set; } = string.Empty;



    // Relations
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}