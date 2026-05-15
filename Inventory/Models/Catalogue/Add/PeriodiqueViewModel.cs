// PeriodiqueViewModel.cs - Updated with all properties
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Models.Catalogue.Add;

public class PeriodiqueViewModel : CatalogueBaseViewModel
{
    [Required(ErrorMessage = "La Cote est obligatoire")]
    [StringLength(50, ErrorMessage = "La Cote ne peut pas dépasser 50 caractères")]
    public string Cote { get; set; } = "";

    [Range(1, 9999, ErrorMessage = "Le nombre d'exemplaires doit être entre 1 et 9999")]
    public int NbrExemplaires { get; set; } = 1;

    [Required(ErrorMessage = "Le Titre Propre est obligatoire")]
    [StringLength(500, ErrorMessage = "Le Titre Propre ne peut pas dépasser 500 caractères")]
    public string TitrePropre { get; set; } = "";

    [StringLength(500)]
    public string TitreCle { get; set; } = "";

    [StringLength(500)]
    public string SousTitre { get; set; } = "";

    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Format ISSN invalide (XXXX-XXXX)")]
    public string ISSN { get; set; } = "";

    public string ID_Periodicite { get; set; } = "";
    public string Periodicite { get; set; } = "";

    [DataType(DataType.Date)]
    public string Date1Pub { get; set; } = "";

    public string NumeroVol { get; set; } = "";

    public bool Accessibilite { get; set; } = true;

    public string Localisation { get; set; } = @"\\SERVEUR-BIBLIO\BIBLIOTHEQUE\FINDER\SCAN\";

    public string CollationImpMaterielle { get; set; } = "";
    public string CollationAutresCarMat { get; set; } = "";
    public string CollationFormat { get; set; } = "";

    public List<AdresseBibliographiqueItem> AdressesBibliographiques { get; set; } = [];

    public string Resume { get; set; } = "";
    public string NoteGenerale { get; set; } = "";

    public string CDD { get; set; } = "";
    public string MentionEdition { get; set; } = "";

    // Collection properties
    public string ID_Collection { get; set; } = "";
    public string TitreCollection { get; set; } = "";
    public string SousTitreCollection { get; set; } = "";
    public string ISSN_Collection { get; set; } = "";
    public string NumDansCollection { get; set; } = "";

    public int ID_Theme { get; set; }
    public string Theme { get; set; } = "";

    public List<string> MotsCles { get; set; } = [];

    public List<PaysItem> PaysListItems { get; set; } = [];

    public int? ID_AuteurPrincipal { get; set; }
    public string NomAuteurPrincipal { get; set; } = "";
    public string AutrePartieAuteurPrincipal { get; set; } = "";
    public decimal Collectivite { get; set; } 

    public List<AuteurSecondaireItem> AuteursSecondaires { get; set; } = [];
    public List<CoAuteurItem> CoAuteurs { get; set; } = [];

    public List<SelectListItem> Themes { get; set; } = [];
    public List<SelectListItem> LanguesList { get; set; } = [];
    public List<SelectListItem> PaysList { get; set; } = [];
    public List<SelectListItem> Fonctions { get; set; } = [];
}

public class AdresseBibliographiqueItem
{
    public int ID_Editeur { get; set; }
    public string NomEditeur { get; set; } = "";
    public int ID_Ville { get; set; }
    public string NomVille { get; set; } = "";
    public string Annee { get; set; } = "";
    public string MentionEdition { get; set; } = "";
}

public class AuteurSecondaireItem
{
    public int ID_Auteur { get; set; }
    public string Nom { get; set; } = "";
    public string AutrePartie { get; set; } = "";
    public decimal Collectivite { get; set; }
    public int ID_Fonction { get; set; }
    public string Fonction { get; set; } = "";
}

public class CoAuteurItem
{
    public int ID_Auteur { get; set; }
    public string Nom { get; set; } = "";
    public string AutrePartie { get; set; } = "";
}

public class LangueItem
{
    public string Code { get; set; } = "";
    public string Nom { get; set; } = "";
}

public class PaysItem
{
    public string Code { get; set; } = "";
    public string Nom { get; set; } = "";
}