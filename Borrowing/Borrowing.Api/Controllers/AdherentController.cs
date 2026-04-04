using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Common;
using Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("api/[controller]")]
public class AdherentController(IPretService pretService, IAdherentService adherentService, INoticeService noticeService, IReservationService reservationService) : ControllerBase
{
    private readonly IPretService _pretService = pretService;
    private readonly IReservationService _reservationService = reservationService;
    private readonly IAdherentService _adherentService = adherentService;

    private readonly INoticeService _noticeService = noticeService;

    [HttpGet]
    public async Task<ActionResult<PagedResult<AdherentDto>>> Get([FromQuery] PaginatedQueryParameters queryParameters)
    {
        var result = await _adherentService.GetAdherentsAsync(queryParameters);
        return Ok(result);
    }

    [HttpGet("Profile")]
    public async Task<ActionResult<AdherentProfileDto>> GetProfileAsync([FromQuery] string Id)
    {
        var adherent = await _adherentService.GetAdherentWithDetailsAsync(Id);

        if (adherent != null)
        {
            return Ok(adherent);
        }
        return NotFound();
    }

    [HttpGet("Pret/Check")]
    public async Task<ActionResult<CheckAdhPretResponseDto>> CheckAdherentPourPret([FromQuery] string id)
    {
        var adherent = await _adherentService.GetAdherentWithDetailsAsync(id);
        if (adherent != null)
        {
            if (adherent.Adherent?.EtatAdherent == 0) // actif
            {
                if (adherent.Adherent?.PenaliteAdherents.Count == 0) // allowed
                {
                    if (adherent.Adherent?.Categorie != null) // categorie exists
                    {
                        int activeLoans = await _pretService.CountAdherentActiveLoans(id); // count active loans
                        if (activeLoans < adherent.Adherent?.Categorie.NombreDocument)
                        {
                            DateTime expectedReturnDate = await _adherentService.CalculateExpectedReturnDate(DateTime.Now.Date, (decimal)adherent.Adherent?.Categorie.DureePret!);
                            return Ok(
                                new CheckAdhPretResponseDto
                                {
                                    Etat = EtatAdherentEnum.AUTHORIZED,
                                    Adherent = adherent.Adherent,
                                    picture = adherent.Picture,
                                    ActiveLoans = activeLoans,
                                    ExpectedReturnDate = expectedReturnDate

                                }
                            );
                        }
                        else
                        {
                            return Ok(
                                new CheckAdhPretResponseDto
                                {
                                    Etat = EtatAdherentEnum.QUOTA_REACHED,
                                    Adherent = adherent.Adherent,
                                    picture = adherent.Picture,
                                    ActiveLoans = activeLoans
                                }
                            );
                        }
                    }
                    else
                    {
                        return Ok(
                            new CheckAdhPretResponseDto
                            {
                                Etat = EtatAdherentEnum.NOT_FOUND,
                            }
                        );
                    }
                }
                else
                {
                    return Ok(
                            new CheckAdhPretResponseDto
                            {
                                Etat = EtatAdherentEnum.PENALISED,
                                Adherent = adherent.Adherent,
                                picture = adherent.Picture
                            }
                        );
                }
            }
            else // bloque
            {
                return Ok(
                            new CheckAdhPretResponseDto
                            {
                                Etat = EtatAdherentEnum.INACTIF,
                                Adherent = adherent.Adherent,
                                picture = adherent.Picture
                            }
                        );
            }
        }
        else
        {
            return Ok(
                new CheckAdhPretResponseDto
                {
                    Etat = EtatAdherentEnum.NOT_FOUND,
                }
            );
        }

    }


    [HttpGet("Restitution/Check")]
    public async Task<ActionResult<CheckAdhRestitutionResponseDto>> CheckAdherentPourRestitution([FromQuery] string AdherentId)
    {
        var adherent =await _adherentService.GetAdherentWithPretsPenaliteAsync(AdherentId);
        if (adherent!= null)
        {
            return Ok(new CheckAdhRestitutionResponseDto
            {
                Adherent = adherent,
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBy606CYdQuQNTxOH0mHl6Lxdker4OH8Nvvg&s"
            });
        }
        return Ok(new CheckAdhRestitutionResponseDto
        {
            Found = false
        });
    }

    [HttpPost]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreateAdherent([FromBody] Borrowing.SharedClasses.Requests.Adherent.CreateAdherentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool success = await _adherentService.CreateAdherentAsync(dto);
        if (success)
            return Ok();
        
        return BadRequest("Impossible de creer l'adherent. Identifiant dejà existant ?");
    }

    [HttpPut]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateAdherent([FromBody] Borrowing.SharedClasses.Requests.Adherent.UpdateAdherentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool success = await _adherentService.UpdateAdherentAsync(dto);
        if (success)
            return Ok();
        
        return NotFound("Adhérent introuvable ou erreur lors de la modification.");
    }

    [HttpGet("Stats")]
    public async Task<ActionResult> GetStats()
    {
        var result =  await  _adherentService.GetStats();
        return Ok(result);
    }   

}