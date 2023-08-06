namespace HRMS.Models;

public class EventUpdate
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int? EventTypeId { get; set; }

    public int? EmployeeId { get; set; }

    public bool AllDay { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }
}