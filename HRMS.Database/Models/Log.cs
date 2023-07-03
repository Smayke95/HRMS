using HRMS.Database.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("Logs")]
public class Log
{
    [Key]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public LogType Type { get; set; }

    public string Message { get; set; } = string.Empty;
}