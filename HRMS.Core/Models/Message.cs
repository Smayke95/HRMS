namespace HRMS.Core.Models;

public class Message : Base
{
    public string Text { get; set; } = string.Empty;

    public DateTime Time { get; set; } = DateTime.Now;

    public string Room { get; set; } = string.Empty;

    public Employee Employee { get; set; } = new();
}