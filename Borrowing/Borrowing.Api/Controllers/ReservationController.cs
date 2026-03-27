using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Common;
using Shared.Models;
using Borrowing.SharedClasses.Reservation.Pret;
namespace Borrowing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly IPretService _pretService;
    private readonly IReservationService _reservationService;
    private readonly IAdherentService _adherentService;

    private readonly INoticeService _noticeService;

    public ReservationController(IPretService pretService, IAdherentService adherentService, INoticeService noticeService, IReservationService reservationService)
    {
        _pretService = pretService;
        _adherentService = adherentService;
        _noticeService = noticeService;
        _reservationService = reservationService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationRequestDto createReservationDto)
    {
        return Ok();
    }
}