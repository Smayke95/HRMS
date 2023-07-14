namespace HRMS.Core.Models;

public class PayGrade : Base
{
    public string Name { get; set; } = string.Empty;

    public decimal MinAmount { get; set; }

    public decimal MaxAmount { get; set; }
}