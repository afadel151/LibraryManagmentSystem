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
public class PretController : ControllerBase
{
    private readonly IPretService _pretService;
    private readonly IReservationService _reservationService;
    private readonly IAdherentService _adherentService;

    private readonly INoticeService _noticeService;

    public PretController(IPretService pretService, IAdherentService adherentService, INoticeService noticeService, IReservationService reservationService)
    {
        _pretService = pretService;
        _adherentService = adherentService;
        _noticeService = noticeService;
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<PretResponseDto>>> Get([FromQuery] PretQueryParameters queryParameters)
    {
        var result = await _pretService.GetPretsAsync(queryParameters);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<CreatePretResponseDto>> CreatePret([FromBody] CreatePretRequestDTo pretRequestDto)
    {
        var result = await _pretService.CreatePretAsync(pretRequestDto);
        return Ok(result);
    }

    [HttpGet("Stats")]
    public async Task<ActionResult<PretStatsDto>> GetStats()
    {
        int prets = await _pretService.CountAsync();
        int reservations = await _reservationService.CountAsync();
        int retard = 5;
        var result = new PretStatsDto
        {
            Prets = prets,
            Reservations = reservations,
            Retard = retard
        };
        return Ok(result);
    }


    
}

