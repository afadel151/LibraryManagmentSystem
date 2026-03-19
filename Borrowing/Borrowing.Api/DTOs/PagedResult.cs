using System.Collections.Generic;

namespace Borrowing.Api.DTOs;

public class PagedResult<T>
{
    public IEnumerable<T> Data { get; set; } = new List<T>();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)System.Math.Ceiling(TotalCount / (double)PageSize);
}
