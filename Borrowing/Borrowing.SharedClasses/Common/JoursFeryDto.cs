namespace Borrowing.SharedClasses.Common;

using LibraryManagement.Shared.Models;

public class JoursFeryDto
{
    public DateTime DateJourFerie { get; set; }
    public string FormattedDate => DateJourFerie.ToString("dd/MM/yyyy");
    public string? NomFerie { get; set; }        // e.g. "Aid El Fitr"
    public string? Description { get; set; }     // from Calendarific
}
