namespace HRMS.Core.Models.Searches;

public class EventSearch : BaseSearch
{
    public string? Name { get; set; }

    public int? EmployeeId { get; set; }

    public bool IncludeEventType { get; set; }

    public bool IncludeEmployee { get; set; }
}