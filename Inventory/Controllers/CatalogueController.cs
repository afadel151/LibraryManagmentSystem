// CatalogueController.cs - Updated with CreatePeriodique action
using System.Text.Json;
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


    public ActionResult Index()
    {
        return View();
    }

    [HttpGet("Add")]
    public ActionResult Add()
    {
        return View("Add/Index");
    }

   
    [HttpPost("Add/Periodique")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreatePeriodique(PeriodiqueViewModel model)
    {
        Console.WriteLine(JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true }));
        if (!ModelState.IsValid)
        {
            model = await periodiqueService.PopulateFormOptionsAsync(model);

            return View("Add/Periodique", model);
        }

        try
        {
            // Create the notice in the database
            var newNotice = await periodiqueService.CreatePeriodiqueAsync(model);
            Console.WriteLine("############ notice ?"+newNotice.Success);
            var newNoticeId = newNotice.Value.IdNotice;
            Console.WriteLine("############ notice id"+newNoticeId);
            TempData["Success"] = "Notice enregistrée avec succès!";
            TempData["NoticeId"] = newNoticeId.ToString();

            if (Request.Form.ContainsKey("SaveAndContinue"))
            {
                return RedirectToAction("AddPeriodique");
            }

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erreur lors de l'enregistrement: {ex.Message}");
            model = await periodiqueService.PopulateFormOptionsAsync(model);
            return View("Add/Periodique", model);
        }
    }

    [HttpGet("Add/Article")]
    public ActionResult AddArticle()
    {
        return View("Add/Article");
    }
    [HttpGet("Add/Periodique")]
    public  async Task<ActionResult> AddPeriodique()
    {
        PeriodiqueViewModel model = new ();
        model = await periodiqueService.PopulateFormOptionsAsync(model);
        return View("Add/Periodique",model);
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