namespace HRMS.Core.Models.Searches;

public class CitySearch : BaseSearch
{
    public string? Name { get; set; }

    public bool IncludeCountry { get; set; }
}