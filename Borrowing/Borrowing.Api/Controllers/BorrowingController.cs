using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.Shared.Requests.Pret;
using Borrowing.Shared.Responses.Pret;
using Shared.Models;
namespace Borrowing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowingController : ControllerBase
{
    private readonly IPretService _pretService;
    private readonly IAdherentService _adherentService;

    private readonly INoticeService _noticeService;

    public BorrowingController(IPretService pretService, IAdherentService adherentService,INoticeService noticeService)
    {
        _pretService = pretService;
        _adherentService = adherentService;
        _noticeService = noticeService;
    }

    [HttpGet("/")]
    public async Task<ActionResult<PagedResult<PretResponseDto>>> Get([FromQuery] PretQueryParameters queryParameters)
    {
        var result = await _pretService.GetPretsAsync(queryParameters);
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreatePretResponseDto>> CreatePret([FromBody] CreatePretRequestDTo pretRequestDto)
    {
        var result = await _pretService.CreatePretAsync(pretRequestDto);
        return Ok(result);
    }

    [HttpGet("lookup_member/{id}")]
    public async Task<IActionResult> LookuMember(string id)
    {
        var adherent = await _adherentService.GetAdherentWithDetailsAsync(id);
        if (adherent != null)
        {
            if (adherent.EtatAdherent == 1)
            {
                Categorie? categorie = await _adherentService.GetAdherentCategorie(id);
                if (categorie != null)
                {
                    int activeLoans = await _pretService.CountAdherentActiveLoans(id);
                    if (activeLoans < categorie.NombreDocument)
                    {
                        return Ok(new { allowed = true });
                    }
                    else
                    {
                        return BadRequest(new { allowed = false });
                    }
                }
                else
                {
                    return NotFound(new { message = "Categorie de l'adherent non trouvee" });
                }
            }
            else
            {
                return BadRequest(new { allowed = false });
            }
        }
        else
        {
            return NotFound(new { message = "Adherent non trouvee" });
        }

    }

    [HttpGet("lookup_notice/{id}/{cote}")]
    public async Task<IActionResult> LookupNotice(string id,string cote)
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

