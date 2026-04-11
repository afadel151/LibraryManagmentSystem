namespace Borrowing.SharedClasses.Common;

using LibraryManagement.Shared.Models;
public class RelanceDto
{
    public string IdAdherent {get;set;} = string.Empty;
    public string Nom {get;set;} = string.Empty;
    public string Prenom {get;set;} = string.Empty;
    public string Position {get;set;} = string.Empty;
    public string Categorie {get;set;} = string.Empty;
    public string Cote {get;set;} = string.Empty;

    public string TitrePropre {get;set;} = string.Empty;
    public decimal IdNotice {get;set;}
}