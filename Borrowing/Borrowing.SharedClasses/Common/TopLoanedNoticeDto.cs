
namespace Borrowing.SharedClasses.Models;

public class TopLoanedNoticeDto
{
    public string TitrePropre { get; set; } = string.Empty;
    public string Cote { get; set; } = null!;
    public int TotalPrets { get; set; }
}