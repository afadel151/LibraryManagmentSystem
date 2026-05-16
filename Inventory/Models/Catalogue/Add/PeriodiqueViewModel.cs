
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Models.Catalogue.Add;

public class PeriodiqueViewModel
{
    //  Identification 

    [Required(ErrorMessage = "La Cote est obligatoire.")]
    [StringLength(24, ErrorMessage = "La Cote ne peut pas dépasser 24 caractères.")]
    [RegularExpression(@"^[^\s;]+$",
        ErrorMessage = "La Cote ne doit contenir ni espace ni point-virgule.")]
    public string Cote { get; set; } = "";

    [Range(1, 9999, ErrorMessage = "Le nombre d'exemplaires doit être entre 1 et 9999.")]
    public int NbrExemplaires { get; set; } = 1;

    [Required(ErrorMessage = "Le Titre Propre est obligatoire.")]
    [StringLength(512, ErrorMessage = "Le Titre Propre ne peut pas dépasser 512 caractères.")]
    public string TitrePropre { get; set; } = "";

    [StringLength(255)]
    public string? TitreCle { get; set; } = "";

    [StringLength(512)]
    public string? SousTitre { get; set; } = "";

    [RegularExpression(@"^\d{4}-\d{3}[\dX]$",
        ErrorMessage = "Format ISSN invalide — attendu : XXXX-XXXX.")]
    public string? ISSN { get; set; }

    public string? ID_Periodicite { get; set; }

    [DataType(DataType.Date)]
    public string? Date1Pub { get; set; }

    [StringLength(50)]
    public string? NumeroVol { get; set; }

    public bool Accessibilite { get; set; } = false;

    [StringLength(255)]
    public string Localisation { get; set; } = @"\\SERVEUR-BIBLIO\BIBLIOTHEQUE\FINDER\SCAN\";

    //  Description physique (Collation) 

    [StringLength(50)]
    public string? CollationImpMaterielle { get; set; }

    [StringLength(50)]
    public string? CollationAutresCarMat { get; set; }

    [StringLength(50)]
    public string? CollationFormat { get; set; }

    //  Auteurs 
    public decimal? IdAuteurPrincipal { get; set; } 
    
    public List<decimal?> IdCoAuteurs          { get; set; } = [];
    public List<AuteurSecondaireItem>  AuteursSecondaires { get; set; } = [];

    //  Indexation 

   
    [StringLength(15)]
    public string? CDD { get; set; }


    [StringLength(15)]
    public string? ID_Theme { get; set; }

    [StringLength(255)]
    public string? ThemeLabel { get; set; }

    public List<string> MotsCles { get; set; } = [];

    [StringLength(2048)]
    public string? Resume { get; set; }

    [StringLength(255)]
    public string? NoteGenerale { get; set; }

    //  Publication 

    public List<AdresseBibliographiqueItem> AdressesBibliographiques { get; set; } = [];

    public List<string> LangueCodes { get; set; } = [];

    public List<string> PaysCodes { get; set; } = [];

    //  Collection 


    public string? ID_Collection         { get; set; }
    public string? TitreCollection       { get; set; }
    public string? SousTitreCollection   { get; set; }
    public string? ISSN_Collection       { get; set; }
    public string? NumDansCollection     { get; set; }

    // ── Mention d'édition 

    [StringLength(2048)]
    public string? MentionEdition { get; set; }


    //populated options
    public List<SelectListItem> PeriodiciteOptions { get; set; } = [];
    public List<SelectListItem> AllMentionRes { get; set; } = [];
    public List<SelectListItem> ThemeOptions       { get; set; } = [];
    public List<SelectListItem> LangueOptions      { get; set; } = [];
    public List<SelectListItem> PaysOptions        { get; set; } = [];
    public List<SelectListItem> FonctionOptions    { get; set; } = [];
}

public class AdresseBibliographiqueItem
{
    [StringLength(50)]
    public string? NomVille   { get; set; }
    [StringLength(255)]
    public string? NomEditeur { get; set; }
    [StringLength(8)]
    public string? Annee { get; set; }
}

public class CoAuteurItem
{
    public string? IdMentionRes { get; set; } 

}

public class AuteurSecondaireItem
{
    public decimal? IdMentionRes { get; set; } 
    public int ID_Fonction { get; set; }
}