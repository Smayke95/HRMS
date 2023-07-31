namespace HRMS.Models;

public class CityInsert
{
    public string Name { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    public int? CountryId { get; set; }
}