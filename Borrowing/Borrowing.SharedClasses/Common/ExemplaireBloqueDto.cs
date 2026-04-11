namespace Borrowing.SharedClasses.Models;

using Common.Models;
public class ExemplaireBloqueDto
{
    public string IdExemplaire { get; set; } = string.Empty;
    public string TitrePropre { get; set; } = string.Empty;
    public decimal IdNotice { get; set; }
    public DateTime DatePret { get; set; }
}