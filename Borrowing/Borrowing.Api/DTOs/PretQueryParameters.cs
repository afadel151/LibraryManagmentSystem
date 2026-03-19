namespace Borrowing.Api.DTOs;

public class PretQueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderBy { get; set; }
}
