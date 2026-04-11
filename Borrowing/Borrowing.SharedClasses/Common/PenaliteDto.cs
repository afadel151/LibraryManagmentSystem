namespace Borrowing.SharedClasses.Models;

using Common.Models;

public class PenaliteDto
{
    public string IdCategorie { get; set; } = string.Empty;
    public string LibelleCategorie { get; set; } = string.Empty;
    public decimal JoursRetard { get; set; }
    public decimal? NombreJoursRetard { get; set; }
}
