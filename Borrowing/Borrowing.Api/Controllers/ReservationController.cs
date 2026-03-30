using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Reservation;
using Borrowing.SharedClasses.Responses.Reservation;
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
    public async Task<ActionResult<CreateReservationResponseDto>> CreateReservation([FromBody] CreateReservationRequestDto createReservationDto)
    {
        if (createReservationDto == null)
        {
            return BadRequest(new CreateReservationResponseDto { Done = false });
        }
        bool reserving = await _reservationService.CheckAdherentReservingCote(createReservationDto.AdherentId, createReservationDto.Cote);
        if (reserving == false)
        {
            var reservation = await _reservationService.CreateReservationAsync(createReservationDto);
            
                return Ok(new CreateReservationResponseDto
                {
                    Done =  reservation != null
                });
        }
        return Ok(new CreateReservationResponseDto{Done = false});
    }
}