using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Categorie;
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

    [Authorize(Roles = "ADMIN")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategorieDto dto)
    {
        var success = await _categorieService.UpdateCategorieAsync(dto);
        if (success)
            return Ok();
        return BadRequest("Failed to update category");
    }

    [Authorize(Roles = "ADMIN")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategorieDto dto)
    {
        var success = await _categorieService.CreateCategorieAsync(dto);
        if (success)
            return Ok();
        return BadRequest("Failed to create category");
    }

    [Authorize(Roles = "ADMIN")]
    [HttpDelete("{idCategorie}")]
    public async Task<IActionResult> Delete(string idCategorie)
    {
        var success = await _categorieService.DeleteCategorieAsync(idCategorie);
        if (success)
            return Ok();
        return BadRequest("Failed to delete category");
    }
}
