using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Responses.Categorie;
using Microsoft.AspNetCore.Authorization;

namespace Borrowing.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategorieController(ICategorieService categorieService) : ControllerBase
{
    private readonly ICategorieService _categorieService = categorieService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategorieDto>>> GetAll()
    {
        var categories = await _categorieService.GetAllCategoriesAsync();
        return Ok(categories);
    }
}
