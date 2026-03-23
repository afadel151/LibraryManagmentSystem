namespace Borrowing.SharedClasses.Common;

using Shared.Models;
public class AdherentDto
{
    public string Id {get;set;} = string.Empty;
    public string Nom {get;set;} = string.Empty;
    public string PreNom {get;set;} = string.Empty;
    public string Position {get;set;} = string.Empty;
    public string Categorie {get;set;} = string.Empty;
    public string Etat {get;set;} = string.Empty;
    // public ICollection<Shared.Models.Pret> Prets {get;set;} = 0;
    public int Reservations {get;set;} = 0;
    public int Retard {get;set;} = 0;

    public string picture {get;set;} = string.Empty;
}
