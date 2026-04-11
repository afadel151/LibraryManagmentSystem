namespace Borrowing.SharedClasses.Models;

using Common.Models;
public class AdherentDto
{
    public string IdAdherent {get;set;} = string.Empty;
    public string Nom {get;set;} = string.Empty;
    public string Prenom {get;set;} = string.Empty;
    public string Position {get;set;} = string.Empty;
    public string Categorie {get;set;} = string.Empty;
    public int Etat {get;set;} = 0;
    public int Prets {get;set;} = 0;
    public int Reservations {get;set;} = 0;
}
