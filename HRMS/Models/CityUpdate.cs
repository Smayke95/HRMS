namespace HRMS.Models;

public class CityUpdate
{
    public string Name { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    public int? CountryId { get; set; }
}