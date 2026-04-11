using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Common;
using LibraryManagement.Shared.Models;
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
        var pret = await _pretService.GetPretByExemplaireId(form.ExemplaireId);
        if (pret != null && pret.IdAdherent == form.AdherentId)
        {
            try
            {
                var success = await _pretService.RestitutionPret(form.AdherentId, form.ExemplaireId);
                if (success)
                {
                    return Ok("Notice restitue avec succe");
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }
        return NotFound("Erreur ");

    }
    [HttpPost("Renouvler")]
    public async Task<IActionResult> RenouvlerPret([FromBody] CreateRestitutionDto form)
    {
       var success = await _pretService.RenouvlementPret(form.AdherentId,form.ExemplaireId);
       if (success)
       {
            return Ok("Renouvlement avec succes");
       }
        return NotFound("Erreur de renouvlement");
    }

}