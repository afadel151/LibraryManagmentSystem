using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Reservation;
using Borrowing.SharedClasses.Responses.Reservation;
using Borrowing.SharedClasses.Common;
using Shared.Models;
namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReservationController(IReservationService reservationService) : ControllerBase
{
    private readonly IReservationService _reservationService = reservationService;

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

    [HttpGet]
    public async Task<ActionResult<PagedResult<Reservation>>> GetAllReservations([FromQuery] PaginatedQueryParameters queryParameters)
    {
        var reservations = await _reservationService.GetPaginated(queryParameters);
        return Ok(reservations);
    }

    [HttpGet("Relances")]
    public async Task<IActionResult> GetAvailabilityRelances()
    {
        List<RelanceDto> List = await _reservationService.GetRelances();
        return Ok(List);
    }
}