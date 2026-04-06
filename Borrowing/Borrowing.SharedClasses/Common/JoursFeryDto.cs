namespace Borrowing.SharedClasses.Common;

using Shared.Models;

public class JoursFeryDto
{
    public DateTime DateJourFerie { get; set; }
    public string FormattedDate => DateJourFerie.ToString("dd/MM/yyyy");
}
