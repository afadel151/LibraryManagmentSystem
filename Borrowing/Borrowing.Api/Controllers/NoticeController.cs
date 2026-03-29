using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Responses.Notice;
using Borrowing.SharedClasses.Common;
using Shared.Models;
using System;
namespace Borrowing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoticeController(
    INoticeService noticeService,
    IPretService pretService,
    IReservationService reservationService
    ) : ControllerBase
{
    private readonly INoticeService _noticeService = noticeService;
    private readonly IReservationService _reservationService = reservationService;
    private readonly IPretService _pretService = pretService;

    [HttpGet("Pret/Check")]
    public async Task<ActionResult<CheckNoticeResponseDto>> CheckNotice([FromQuery]  string cote, [FromQuery]  string AdherentId)
    {
        // fetch notice
        var notice = await _noticeService.GetNoticeWithDetailsByCoteAsync(cote);
        // combien de copies dispo
        if (notice == null)
        {
            return Ok(new CheckNoticeResponseDto {
                Found = false 
            });
        }

        List<string> availableCopies = [.. notice.Exemplaires.Where(e => e.IdEtat == 1).Select(e => e.IdExemplaire)];
        // est ce que l'adherent a reserve ce livre
        // copies bloquees 99/999
        List<Pret> noticeReservations = await _pretService.GetBlockedCopies(cote);
        // si reservateur
        if (notice.Reservations.Any(r => r.IdAdherent == AdherentId))
        {
            // reservateurs FIFO par rapport HEURE_RESERVATION
            var orderedReservations = await _reservationService.GetAllDescByHeur(noticeReservations.Count);
            // s'il appartient au top N par rapport a HEURE_RESERVATION il peut preter
            if (orderedReservations.Any(r => r.IdAdherent == AdherentId))
            {
                // peut preter le livre 
                int queuPosition = orderedReservations.FindIndex(r => r.IdAdherent == AdherentId);
                // retourner la copie + qu'il est reservateur
                // return noticeReservations.ElementAt(queuPosition).IdExemplaire;
                return Ok(new CheckNoticeResponseDto 
                { 
                    CanBorrow = true, 
                    Message = "Vous pouvez preter", 
                    Exemplaires = new List<string> { noticeReservations.ElementAt(queuPosition).IdExemplaire }, 
                    Reservateur = true, 
                    Titre = notice.Notice?.TitrePropre! 
                });
            }
            else
            {
                // block : membre ne put pas preter car les copies sont bloquee pour les reservateurs qui ont plus de droit
                return Ok(new CheckNoticeResponseDto { 
                    CanReserve = true, 
                    Message = "Votre copie n'a pas encore etait rendue ", 
                    Titre = notice.Notice?.TitrePropre! });
            }
        }
        else
        {
            // n'est pas un reservateur
            if (availableCopies.Count > 0)
            {
                // return available copies
                return Ok(new CheckNoticeResponseDto { 
                    Message = "Vous pouvez preter", 
                    Exemplaires = availableCopies, 
                    CanBorrow = true, 
                    Titre = notice.Notice?.TitrePropre! 
                });
            }
            else
            {
                // sinon dire qu'il n'ya pas une copie + Boutton Reserver 
                return Ok(new CheckNoticeResponseDto { 
                    CanBorrow = false, 
                    CanReserve = true, 
                    Message = "Pas de copies dispo, vous pouvez reserver", 
                    Titre = notice.Notice?.TitrePropre! 
                });
            }
        }
    }
}