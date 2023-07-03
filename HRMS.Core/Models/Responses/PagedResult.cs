namespace HRMS.Core.Models.Responses;

public class PagedResult<T>
{
    public List<T> Result { get; set; } = new();

    public int TotalCount { get; set; }

    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}