namespace HRMS.Core.Models;

public class Education : Base
{
    public string ISCED { get; set; } = string.Empty;

    public int EQF { get; set; }

    public string Qualification { get; set; } = string.Empty;

    public string FinishedEducation { get; set; } = string.Empty;

    public string QualificationOld { get; set; } = string.Empty;

    public string FinishedEducationOld { get; set; } = string.Empty;
}