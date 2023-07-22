namespace HRMS.Core.Models.Searches;

public class MessageSearch : BaseSearch
{
    public string? Room { get; set; }

    public bool IncludeEmployee { get; set; }
}