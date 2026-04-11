namespace Borrowing.SharedClasses.Requests.Categorie;

public class UpdateCategorieDto
{
    public string IdCategorie { get; set; } = string.Empty;
    public string LibelleCategorie { get; set; } = string.Empty;
    public decimal? NombreDocument { get; set; }
    public decimal? DureePret { get; set; }
}
