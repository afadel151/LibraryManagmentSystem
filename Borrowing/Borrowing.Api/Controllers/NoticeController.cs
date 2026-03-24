using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Common;
using Shared.Models;
using System;
namespace Borrowing.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class NoticeController : ControllerBase
{
    private readonly INoticeService _noticeService;
    public NoticeController(
        INoticeService noticeService
    )
    {
        _noticeService = noticeService;
    }

    [HttpGet("Pret/Check/{cote}/{AdherentId}")]
    public async Task<IActionResult> CheckNotice(string cote,string AdherentId)
    {
        var notice = await _noticeService.GetNoticeWithDetailsByCoteAsync(cote);
        return Ok(notice);
    }
}