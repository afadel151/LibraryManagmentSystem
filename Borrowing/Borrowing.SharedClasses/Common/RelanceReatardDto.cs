namespace Borrowing.SharedClasses.Common;

using LibraryManagement.Shared.Models;
public class RelanceRetardDto
{
    public string IdAdherent {get;set;} = string.Empty;
    public string Nom {get;set;} = string.Empty;
    public string Prenom {get;set;} = string.Empty;
    public string Position {get;set;} = string.Empty;
    public string Categorie {get;set;} = string.Empty;
    public int PretsEncours {get;set;}
    public int PenaliteEnCours {get;set;}
}