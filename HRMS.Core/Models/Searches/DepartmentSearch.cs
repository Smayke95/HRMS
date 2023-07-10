namespace HRMS.Core.Models.Searches;

public class DepartmentSearch : BaseSearch
{
    public string? Name { get; set; }

    public bool IncludeParentDepartment { get; set; }

    public bool IncludeSupervisor { get; set; }
}