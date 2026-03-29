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
    public async Task<ActionResult<PagedResult<PretResponseDto>>> Get([FromQuery] PaginatedQueryParameters queryParameters)
    {
        var result = await _pretService.GetPretsAsync(queryParameters);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<CreatePretResponseDto?>> CreatePret([FromBody] CreatePretRequestDto pretRequestDto)
    {
        var adherent  = await _adherentService.GetAdherentWithDetailsAsync(pretRequestDto.AdherentId);
        if (adherent == null)
        {
            return Ok(
                new CreatePretResponseDto
                {
                    Done = false,
                    Message = "Adherent not found"
                }
            );
        }
        var pret = await _pretService.GetPretByExemplaireId(pretRequestDto.ExemplaireId);
        var exemplaire = await _noticeService.GetExemplaireAsync(pretRequestDto.ExemplaireId);
        if (exemplaire == null)
        {
            return Ok(
                new CreatePretResponseDto
                {
                    Done = false,
                    Message = "Exemplaire not found"
                }
            );
        }
        else
        {
            if (exemplaire.IdEtat != 1)
            {
                return Ok(
                    new CreatePretResponseDto
                    {
                        Done = false,
                        Message = "Exemplaire is not available for loan"
                    }
                );
            }
        }
        if (pret != null)
        {
            return Ok(
                new CreatePretResponseDto
                {
                    Done = false,
                    Message = "Exemplaire is already on loan"
                }
            );
        }

        var result = await _pretService.CreatePretAsync(pretRequestDto);
        if (result != null)
        {
            return Ok(
                new CreatePretResponseDto
                {
                    Done = true,
                    Message = "Pret created successfully"
                }
            );
        }
        else
        {
            return Ok(
                new CreatePretResponseDto
                {
                    Done = false,
                    Message = "Failed to create pret"
                }
            );
        }
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

