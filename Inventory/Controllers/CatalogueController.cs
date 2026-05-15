using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers;

public class CatalogueController : Controller
{
    // GET: CatalogueController
    public ActionResult Index()
    {
        return View();
    }

}

