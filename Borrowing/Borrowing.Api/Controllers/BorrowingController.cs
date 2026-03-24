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
public class BorrowingController : ControllerBase
{
    private readonly IPretService _pretService;
    private readonly IReservationService _reservationService;
    private readonly IAdherentService _adherentService;

    private readonly INoticeService _noticeService;

    public BorrowingController(IPretService pretService, IAdherentService adherentService, INoticeService noticeService, IReservationService reservationService)
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


    [HttpGet("LookupNotice/{id}/{cote}")]
    public async Task<IActionResult> LookupNotice(string id, string cote)
    {
        var notice = await _noticeService.GetNoticeAsync(cote);
        if (notice != null)
        {
            //  ?? que signifie 99/999 dans la table pret
            // pourquoi insert apret delete 
            // 1 - voir si l'aherent a deja pri ce livre
            // 2 - avoir les copies disponibles
            // 3 - combien d'ecemplaires sont bloquee pour ce livre si  
            // 4 - si l'adherent a  deja reserve ce livre si oui  
        }
        return Ok();
    }
}

