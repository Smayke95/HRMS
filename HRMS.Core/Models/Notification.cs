using HRMS.Core.Models.Enums;
using System.Text.Json;

namespace HRMS.Core.Models;

public class Notification
{
    public NotificationType Type { get; set; } = NotificationType.Info;

    public Role Group { get; set; } = Role.Admin;

    public string Text { get; set; } = string.Empty;



    public string ToJson()
        => JsonSerializer.Serialize(this, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
}