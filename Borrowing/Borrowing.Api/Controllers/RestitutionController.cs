using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Models;
using Common.Models;
using Borrowing.SharedClasses.Requests.Restitution;
namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("api/[controller]")]
public class RestitutionController(
    IPretService pretService
    ) : ControllerBase
{
    private readonly IPretService _pretService = pretService;


    [HttpPost("Restituer")]
    public async Task<IActionResult> PerformRestitution([FromBody] CreateRestitutionDto form)
    {
        ArgumentNullException.ThrowIfNull(form);

        var pret = await _pretService.GetPretByExemplaireId(form.ExemplaireId);

        if (pret == null)
            return Ok(ApiResult.Fail("Prêt introuvable pour cet exemplaire.", "PRET_NOT_FOUND"));

        if (pret.IdAdherent != form.AdherentId)
            return Ok(ApiResult.Fail("L'adhérent ne correspond pas à ce prêt.", "ADHERENT_MISMATCH"));

        var result = await _pretService.RestitutionPret(form.AdherentId, form.ExemplaireId);
        
        return Ok(result);
    }



    [HttpPost("Renouvler")]
    public async Task<IActionResult> RenouvlerPret([FromBody] CreateRestitutionDto form)
    {
        ArgumentNullException.ThrowIfNull(form);
        var success = await _pretService.RenouvlementPret(form.AdherentId, form.ExemplaireId);
        if (success)
        {
            return Ok("Renouvlement avec succes");
        }
        return NotFound("Erreur de renouvlement");
    }

}