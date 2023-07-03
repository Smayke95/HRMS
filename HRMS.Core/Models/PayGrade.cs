namespace HRMS.Core.Models;

public class PayGrade
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal MinAmount { get; set; }

    public decimal MaxAmount { get; set; }
}