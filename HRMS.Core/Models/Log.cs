using HRMS.Core.Enums.Model;

namespace HRMS.Core.Models;

public class Log
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public LogType Type { get; set; }

    public string Message { get; set; } = string.Empty;
}