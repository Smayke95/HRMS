namespace HRMS.Core.Models;

public class Position : Base
{
    public string Name { get; set; } = string.Empty;

    public Department Department { get; set; } = new();

    public PayGrade PayGrade { get; set; } = new();

    public Education RequiredEducation { get; set; } = new();

    public bool IsWorkExperienceRequired { get; set; }
}