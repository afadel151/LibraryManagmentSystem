namespace Borrowing.SharedClasses.Requests.Adherent;

public class CreateAdherentDto
{
    public string IdAdherent { get; set; } = string.Empty;
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public decimal IdPosition { get; set; }
    public string IdCategorie { get; set; } = string.Empty;
}
