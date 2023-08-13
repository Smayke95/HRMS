namespace HRMS.Models;

public class EventTypeInsert
{
    public string Name { get; set; } = string.Empty;

    public bool IsApprovalRequired { get; set; } = true;

    public string Color { get; set; } = string.Empty;
}