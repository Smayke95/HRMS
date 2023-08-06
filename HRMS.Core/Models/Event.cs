using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Models;

public class Event : Base
{
    public string Name { get; set; } = string.Empty;

    //public EventType EventType { get; set; } = new();

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Description { get; set; } = string.Empty;

    public Employee Employee { get; set; } = new();
}