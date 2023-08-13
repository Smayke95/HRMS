namespace HRMS.Core.Models;

public class EventType : Base
{
    public string Name { get; set; } = string.Empty;

    public bool IsApprovalRequired { get; set; } = true;

    public string Color { get; set; } = string.Empty;
}