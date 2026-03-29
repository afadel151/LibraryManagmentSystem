using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Common;
using Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Borrowing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdherentController : ControllerBase
{
    private readonly IPretService _pretService;
    private readonly IReservationService _reservationService;
    private readonly IAdherentService _adherentService;

    private readonly INoticeService _noticeService;

    public AdherentController(IPretService pretService, IAdherentService adherentService, INoticeService noticeService, IReservationService reservationService)
    {
        _pretService = pretService;
        _adherentService = adherentService;
        _noticeService = noticeService;
        _reservationService = reservationService;
    }

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

    [HttpGet("Pret/Check/{id}")]
    public async Task<ActionResult<CheckAdhResponseDto>> CheckAdherent(string id)
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
                                new CheckAdhResponseDto
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
                                new CheckAdhResponseDto
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
                            new CheckAdhResponseDto
                            {
                                Etat = EtatAdherentEnum.NOT_FOUND,
                            }
                        );
                    }
                }
                else
                {
                    return Ok(
                            new CheckAdhResponseDto
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
                            new CheckAdhResponseDto
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
                new CheckAdhResponseDto
                {
                    Etat = EtatAdherentEnum.NOT_FOUND,
                }
            );
        }

    }


    [HttpGet("Stats")]
    public async Task<ActionResult> GetStats()
    {
        var result =  await  _adherentService.GetStats();
        return Ok(result);
    }   

}