using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;

namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("api/[controller]")]
public class PenaliteController : ControllerBase
{
    private readonly IPenaltieService _penaltieService;

    public PenaliteController(IPenaltieService penaltieService)
    {
        _penaltieService = penaltieService;
    }

    [HttpDelete("{adherentId}/{datePenalite}")]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeletePenalite(string adherentId, DateTime datePenalite)
    {
        var success = await _penaltieService.DeletePenaliteAsync(adherentId, datePenalite);
        if (success)
        {
            return Ok();
        }
        
        return NotFound("Pénalité introuvable ou impossible à supprimer.");
    }
}
