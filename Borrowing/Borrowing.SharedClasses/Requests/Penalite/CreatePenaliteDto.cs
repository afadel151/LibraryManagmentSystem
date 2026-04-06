namespace Borrowing.SharedClasses.Requests.Penalite;

public class CreatePenaliteDto
{
    public string IdCategorie { get; set; } = string.Empty;
    public decimal JoursRetard { get; set; }
    public decimal? NombreJoursRetard { get; set; }
}
