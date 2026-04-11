using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Common;
using LibraryManagement.Shared.Models;
namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("api/[controller]")]
public class PretController(IPretService pretService, IPenaliteAdherentService penaltieService, IAdherentService adherentService, INoticeService noticeService, IReservationService reservationService) : ControllerBase
{
    private readonly IPretService _pretService = pretService;
    private readonly IReservationService _reservationService = reservationService;
    private readonly IAdherentService _adherentService = adherentService;

    private readonly INoticeService _noticeService = noticeService;
    private readonly IPenaliteAdherentService _penaliteService = penaltieService;

    [HttpGet]
    public async Task<ActionResult<PagedResult<PretResponseDto>>> Get([FromQuery] PaginatedQueryParameters queryParameters)
    {
        var result = await _pretService.GetPretsAsync(queryParameters);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<CreatePretResponseDto?>> CreatePret([FromBody] CreatePretRequestDto pretRequestDto)
    {
        var adherentCheck = await _adherentService.CheckAdherentPourPret(pretRequestDto.AdherentId);
        string cote = pretRequestDto.ExemplaireId[..pretRequestDto.ExemplaireId.LastIndexOf('/')];
        var noticeCheck = await _noticeService.CheckNoticeAsync(cote, pretRequestDto.AdherentId);
        var pret = await _pretService.GetPretByExemplaireId(pretRequestDto.ExemplaireId);
        var exemplaire = await _noticeService.GetExemplaireAsync(pretRequestDto.ExemplaireId);

        if (adherentCheck.Etat != CheckAdherentEnum.AUTHORIZED || exemplaire == null || exemplaire.IdEtat != 1 || pret != null || noticeCheck.Status != CheckNoticeEnum.CAN_BORROW)
        {
            return Ok(
                new CreatePretResponseDto
                {
                    Done = false,
                }
            );
        }
        var succesPret = await _pretService.CreatePretAsync(pretRequestDto);
        if (succesPret)
        {
            var succesExemplaire = await _noticeService.UpdateExemplaire(exemplaire, 2);
            if (!succesExemplaire)
            {
                await _pretService.DeletePret(pretRequestDto.AdherentId, pretRequestDto.ExemplaireId);
                return Ok(
                    new CreatePretResponseDto
                    {
                        Done = false,
                        Message = "Failed to create pret"
                    }
                );
            }
            else
            {
                return Ok(
                    new CreatePretResponseDto
                    {
                        Done = true,
                        Message = "Pret creatd successfully"
                    }
                );
            }
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
        int retard = await _penaliteService.CountNegativePenalties();
        var result = new PretStatsDto
        {
            Prets = prets,
            Reservations = reservations,
            Retard = retard
        };
        return Ok(result);
    }



}

