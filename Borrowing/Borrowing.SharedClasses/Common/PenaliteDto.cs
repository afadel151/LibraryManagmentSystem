namespace Borrowing.SharedClasses.Common;

using LibraryManagement.Common.Models;

public class PenaliteDto
{
    public string IdCategorie { get; set; } = string.Empty;
    public string LibelleCategorie { get; set; } = string.Empty;
    public decimal JoursRetard { get; set; }
    public decimal? NombreJoursRetard { get; set; }
}
