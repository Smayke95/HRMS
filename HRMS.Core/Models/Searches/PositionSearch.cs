namespace HRMS.Core.Models.Searches;

public class PositionSearch : BaseSearch
{
    public string? Name { get; set; }

    public bool IncludeDepartment { get; set; }

    public bool IncludePayGrade { get; set; }

    public bool IncludeEducation { get; set; }
}