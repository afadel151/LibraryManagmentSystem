using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Common;
using Shared.Models;
using Borrowing.SharedClasses.Requests.Restitution;
namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("api/[controller]")]
public class RestitutionController(
    IPretService pretService,
    IAdherentService adherentService,
    INoticeService noticeService,
    IReservationService reservationService,
    IRestitutionService restitutionService,
    IPenaltieService penaltieService
    ) : ControllerBase
{
    private readonly IPretService _pretService = pretService;
    private readonly IReservationService _reservationService = reservationService;
    private readonly IAdherentService _adherentService = adherentService;
    private readonly INoticeService _noticeService = noticeService;
    private readonly IRestitutionService _restitutionService = restitutionService;
    private readonly IPenaltieService _penaliteService = penaltieService;



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
        return Ok();
    }

}