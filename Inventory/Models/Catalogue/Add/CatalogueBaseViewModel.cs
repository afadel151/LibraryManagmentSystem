using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Models.Catalogue.Add;

public abstract class CatalogueBaseViewModel
{
    public List<SelectListItem> Periodicites { get; set; } = [];
    public List<SelectListItem> Pays { get; set; } = [];
    public List<SelectListItem> Editeurs    { get; set; } = [];
    public List<SelectListItem> Langues     { get; set; } = [];
}