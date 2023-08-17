namespace HRMS.Models;

public class EventInsert
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int? EventTypeId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}