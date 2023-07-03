namespace HRMS.Core.Models;

public class City
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    public Country Country { get; set; } = new();
}