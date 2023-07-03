namespace HRMS.Core.Models;

public class Notification
{
    public int Id { get; set; }

    public Employee Employee { get; set; } = new();

    public string Text { get; set; } = string.Empty;

    public bool IsReaded { get; set; }
}