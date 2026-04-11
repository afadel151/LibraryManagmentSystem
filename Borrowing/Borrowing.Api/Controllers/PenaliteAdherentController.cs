using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Common;

namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("api/[controller]")]
public class PenaliteAdherentController(IPenaliteAdherentService penaltieAdherentService) : ControllerBase
{
    private readonly IPenaliteAdherentService _penaltieAdherentService = penaltieAdherentService;

    [HttpDelete("{adherentId}/{datePenalite}")]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeletePenaliteAdherent(string adherentId, DateTime datePenalite)
    {
        var success = await _penaltieAdherentService.DeletePenaliteAsync(adherentId, datePenalite);
        if (success)
        {
            return Ok();
        }
        
        return NotFound("Pénalité introuvable ou impossible à supprimer.");
    }

    [HttpGet]
    public async Task<ActionResult<List<RelanceDto>>> GetRelancesRetard()
    {
        var result = await _penaltieAdherentService.GetRelancesRetard();
        return Ok(result);
    }
}
