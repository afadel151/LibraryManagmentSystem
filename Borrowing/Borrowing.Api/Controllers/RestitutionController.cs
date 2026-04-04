using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Common;
using Shared.Models;
namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("api/[controller]")]
public class RestitutionController(
    IPretService pretService, 
    IAdherentService adherentService, 
    INoticeService noticeService, 
    IReservationService reservationService,
    IRestitutionService restitutionService
    ) : ControllerBase
{
    private readonly IPretService _pretService = pretService;
    private readonly IReservationService _reservationService = reservationService;
    private readonly IAdherentService _adherentService = adherentService;
    private readonly INoticeService _noticeService = noticeService;
    private readonly IRestitutionService _restitutionService = restitutionService;

    
}