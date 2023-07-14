using HRMS.Core.Models.Enums;

namespace HRMS.Core.Models;

public class Log : Base
{
    public DateTime Date { get; set; }

    public LogType Type { get; set; }

    public string Message { get; set; } = string.Empty;
}