namespace Borrowing.SharedClasses.Common;

using Shared.Models;
public class NoticeDto
{
    public decimal IdNotice { get; set; } 
    public string? TitrePropre { get; set; }
    public string? Cote { get; set; }
    public string TypeNotice1 {get;set;} = string.Empty;
    public int ExemplaireDispo { get; set; }
    public int ExemplaireEnPret { get; set; }
    public int Reservations { get; set; }
}