namespace HRMS.Core.Models.Searches;

public class EmployeeSearch : BaseSearch
{
    public string? Name { get; set; }

    public bool IncludeCity { get; set; }

    public bool IncludeCountry { get; set; }

    public bool IncludeEducation { get; set; }
}