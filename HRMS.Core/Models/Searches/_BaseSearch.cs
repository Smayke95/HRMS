namespace HRMS.Core.Models.Searches;

public class BaseSearch
{
    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}