using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Common;
using Shared.Models;
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

    [HttpGet("pret/check/{id}")]
    public async Task<ActionResult<CheckAdhResponseDto>> LookuMember(string id)
    {
        var adherent = await _adherentService.GetAdherentWithDetailsAsync(id);
        if (adherent != null)
        {
            if (adherent.EtatAdherent == 1)
            {
                Categorie? categorie = await _adherentService.GetAdherentCategorie(id);
                if (categorie != null)
                {
                    int activeLoans = await _pretService.CountAdherentActiveLoans(id);
                    if (activeLoans < categorie.NombreDocument)
                    {
                        return Ok(
                            new CheckAdhResponseDto
                            {
                                Allowed = true,
                                Adherent = adherent,
                                picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBy606CYdQuQNTxOH0mHl6Lxdker4OH8Nvvg&s",
                                ActiveLoans = activeLoans,
                                
                            }
                        );
                    }
                    else
                    {
                        return Ok(
                            new CheckAdhResponseDto
                            {
                                Allowed = false,
                                Adherent = adherent,
                                message = "Vous pouvez pas faire encore de prets",
                                picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBy606CYdQuQNTxOH0mHl6Lxdker4OH8Nvvg&s",
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
                            Allowed = false,
                            message = "Categorie de l'adherent non trouvee"
                        }
                    );
                }
            }
            else
            {
                return Ok(
                        new CheckAdhResponseDto
                        {
                            Allowed = false,
                            message = "Adherent Penalise/Bloque",
                            Adherent = adherent,
                            picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBy606CYdQuQNTxOH0mHl6Lxdker4OH8Nvvg&s"
                        }
                    );
            }
        }
        else
        {
            return NotFound(
                new CheckAdhResponseDto
                {
                    Allowed = false,
                    message = "Adherent Non trouve"
                }
            );
        }

    }

}