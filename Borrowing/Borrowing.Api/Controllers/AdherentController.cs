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

    [HttpGet("Pret/Check/{id}")]
    public async Task<ActionResult<CheckAdhResponseDto>> CheckAdherent(string id)
    {
        var adherent = await _adherentService.GetAdherentWithDetailsAsync(id);
        if (adherent != null)
        {
            if (adherent.EtatAdherent == 1) // allowed
            {
                Categorie? categorie = await _adherentService.GetAdherentCategorie(id);
                if (categorie != null) // categorie exists
                {
                    int activeLoans = await _pretService.CountAdherentActiveLoans(id); // count active loans
                    if (activeLoans < categorie.NombreDocument)
                    {
                        DateTime expectedReturnDate = await _adherentService.CalculateExpectedReturnDate(DateTime.Now.Date, (decimal)categorie.DureePret!);
                        return Ok(
                            new CheckAdhResponseDto
                            {
                                Allowed = true,
                                Adherent = adherent,
                                picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBy606CYdQuQNTxOH0mHl6Lxdker4OH8Nvvg&s",
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
            return Ok(
                new CheckAdhResponseDto
                {
                    Allowed = false,
                    message = "Adherent Non trouve"
                }
            );
        }

    }


    

}