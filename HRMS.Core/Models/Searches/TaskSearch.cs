namespace HRMS.Core.Models.Searches;

public class TaskSearch : BaseSearch
{
    public string? Name { get; set; }

    public bool IncludeProject { get; set; }

    public bool IncludeStatus { get; set; }

    public bool IncludeType { get; set; }

    public bool IncludeEmployee { get; set; }
}