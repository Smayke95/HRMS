namespace HRMS.Core.Models;

public class City : Base
{
    public string Name { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    public Country Country { get; set; } = new();
}