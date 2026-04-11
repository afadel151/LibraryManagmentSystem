namespace Borrowing.SharedClasses.Responses.Notice;

using Borrowing.SharedClasses.Common;
using LibraryManagement.Shared.Models;
public class CheckNoticeResponseDto
{
    public CheckNoticeEnum Status { get; set; }
    public string? Titre { get; set; }
    public List<string>? Exemplaires { get; set; }
}