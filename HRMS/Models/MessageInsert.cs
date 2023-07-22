namespace HRMS.Models;

public class MessageInsert
{
    public string Text { get; set; } = string.Empty;

    public string Room { get; set; } = string.Empty;

    public int EmployeeId { get; set; }
}