using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Responses.Notice;
using Borrowing.SharedClasses.Common;
using LibraryManagement.Shared.Models;
using System;
namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
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
    public async Task<ActionResult<CheckNoticeResponseDto>> CheckNotice([FromQuery] string cote, [FromQuery] string AdherentId)
    {
        var result = await _noticeService.CheckNoticeAsync(cote, AdherentId);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<NoticeDto>>> Get([FromQuery] PaginatedQueryParameters queryParameters)
    {
        var result = await _noticeService.GetNoticesAsync(queryParameters);
        return Ok(result);
    }


    [HttpGet("Chart")]
    public async Task<IActionResult> GetChart()
    {
        var result = await _noticeService.GetTopLoanedNoticesAsync(10);
        return Ok(result);
    }
    [HttpGet("Profile")]
    public async Task<ActionResult<NoticeProfileDto>> GetNoticeProile([FromQuery] int Id)
    {
        var result = await _noticeService.GetNoticeProfile(Id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }


    [HttpGet("Exemplaire")]
    public async Task<ActionResult<Exemplaire>> GetExemplaireById([FromQuery] string Id)
    {
        var exemplaire = await _noticeService.GetExemplaireDetailedAsync(Id);
        if (exemplaire == null)
        {
            return NotFound();
        }
        return Ok(exemplaire);
    }

    [HttpGet("Exemplaire/Bloques")]
    public async Task<ActionResult<PagedResult<ExemplaireBloqueDto>>> GetBlockedCopies([FromQuery] PaginatedQueryParameters parameters)
    {
        Console.WriteLine("#### API triggered");
        var result = await _noticeService.GetExemplaireBloquesAsync(parameters);
        return Ok(result);
    }

}