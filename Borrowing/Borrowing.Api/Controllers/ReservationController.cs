using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Common;
using Shared.Models;
using Borrowing.SharedClasses.Requests.Reservation;
namespace Borrowing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController(IPretService pretService, IAdherentService adherentService, INoticeService noticeService, IReservationService reservationService) : ControllerBase
{
    private readonly IPretService _pretService = pretService;
    private readonly IReservationService _reservationService = reservationService;
    private readonly IAdherentService _adherentService = adherentService;

    private readonly INoticeService _noticeService = noticeService;

    [HttpPost("Create")]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationRequestDto createReservationDto)
    {
        return Ok();
    }
}