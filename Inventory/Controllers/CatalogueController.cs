// CatalogueController.cs - Updated with CreatePeriodique action
using Inventory.Models.Catalogue.Add;
using Inventory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Controllers;

public class CatalogueController(
    INoticeService noticeService,
    IPeriodiqueService periodiqueService

) : Controller
{
    private readonly INoticeService _noticeService = noticeService;
    private readonly IPeriodiqueService _periodiqueService = periodiqueService;

    public ActionResult Index()
    {
        return View();
    }

    [HttpGet("Add")]
    public ActionResult Add()
    {
        return View("Add/Index");
    }

    [HttpGet("Add/Periodique")]
    public async Task<ActionResult> AddPeriodique()
    {
        var periodicites = await _noticeService.GetPeriodicites();
        var fonctions = await _noticeService.GetFonctions();
        var pays  = await _noticeService.GetPays();
        var model = new PeriodiqueViewModel
        {
            Periodicites = [.. periodicites.Select(p => new SelectListItem
            {
                Value = p.IdPeriodicite,
                Text = p.Periodicite1
            })],
            Fonctions = [.. fonctions.Select(f => new SelectListItem
            {
                Value = f.IdFonction.ToString(),
                Text = f.Fonction1
            })],
            Pays = [.. pays.Select(f => new SelectListItem
            {
                Value = f.IdPays.ToString(),
                Text = f.Pays
            })]
        };

        return View("Add/Periodique", model);
    }

    [HttpPost("CreatePeriodique")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreatePeriodique(PeriodiqueViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // Reload dropdown lists
            var periodicites = await _noticeService.GetPeriodicites();
            var fonctions = await _noticeService.GetFonctions();
            
            model.Periodicites = [.. periodicites.Select(p => new SelectListItem
            {
                Value = p.IdPeriodicite,
                Text = p.Periodicite1
            })];
            model.Fonctions = [.. fonctions.Select(f => new SelectListItem
            {
                Value = f.IdFonction.ToString(),
                Text = f.Fonction1
            })];
            
            return View("Add/Periodique", model);
        }

        try
        {
            // Create the notice in the database
            var newNotice = await _periodiqueService.CreatePeriodiqueNotice(model);
            var newNoticeId = newNotice.IdNotice;
            
            TempData["Success"] = "Notice enregistrée avec succès!";
            TempData["NoticeId"] = newNoticeId;
            
            if (Request.Form.ContainsKey("SaveAndContinue"))
            {
                return RedirectToAction("AddPeriodique");
            }
            
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erreur lors de l'enregistrement: {ex.Message}");
            
            // Reload dropdown lists
            var periodicites = await _noticeService.GetPeriodicites();
            var fonctions = await _noticeService.GetFonctions();
            
            model.Periodicites = [.. periodicites.Select(p => new SelectListItem
            {
                Value = p.IdPeriodicite,
                Text = p.Periodicite1
            })];
            model.Fonctions = [.. fonctions.Select(f => new SelectListItem
            {
                Value = f.IdFonction.ToString(),
                Text = f.Fonction1
            })];
            
            return View("Add/Periodique", model);
        }
    }

    [HttpGet("Add/Article")]
    public ActionResult AddArticle()
    {
        return View("Add/Article");
    }

    [HttpGet("Add/These")]
    public ActionResult AddThese()
    {
        return View("Add/These");
    }

    [HttpGet("Add/Monographie")]
    public ActionResult AddMonographie()
    {
        return View("Add/Monographie");
    }

    [HttpGet("Add/Electric")]
    public ActionResult AddElectric()
    {
        return View("Add/Electric");
    }

    [HttpGet("Add/Extrait")]
    public ActionResult AddExtrait()
    {
        return View("Add/Extrait");
    }
}