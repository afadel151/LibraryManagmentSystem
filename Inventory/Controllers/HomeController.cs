using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Inventory.Services;

namespace Inventory.Controllers;

public class HomeController(IDashboardService dashboardService)  : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }
   [Authorize]
    public async Task<IActionResult> Dashboard()
    {
        var stats = await dashboardService.GetStatsAsync();
        return View(stats);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
