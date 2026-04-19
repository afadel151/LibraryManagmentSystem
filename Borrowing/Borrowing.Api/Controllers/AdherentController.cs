using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Models;
using Common.Models;
namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("api/[controller]")]
public class AdherentController(IAdherentService adherentService) : ControllerBase
{
    private readonly IAdherentService _adherentService = adherentService;


    [HttpGet]
    public async Task<ActionResult<PagedResult<AdherentDto>>> Get([FromQuery] PaginatedQueryParameters queryParameters)
    {
        ArgumentNullException.ThrowIfNull(queryParameters);
        var result = await _adherentService.GetAdherentsAsync(queryParameters);
        return Ok(result);
    }

    [HttpGet("Profile")]
    public async Task<ActionResult<AdherentProfileDto>> GetProfileAsync([FromQuery] string Id)
    {
        ArgumentNullException.ThrowIfNull(Id);
        var adherent = await _adherentService.GetAdherentWithDetailsAsync(Id);

        if (adherent != null)
        {
            return Ok(adherent);
        }
        return NotFound();
    }

    [HttpGet("Pret/Check")]
    public async Task<ActionResult<CheckAdhPretResponseDto>> CheckAdherentPourPret([FromQuery] string id)
    {
        ArgumentNullException.ThrowIfNull(id);
        var result = await _adherentService.CheckAdherentPourPret(id);
        return Ok(result);
    }


    [HttpGet("Restitution/Check")]
    public async Task<ActionResult<CheckAdhRestitutionResponseDto>> CheckAdherentPourRestitution([FromQuery] string AdherentId)
    {
        ArgumentNullException.ThrowIfNull(AdherentId);
        var adherent = await _adherentService.GetAdherentWithPretsPenaliteAsync(AdherentId);
        if (adherent != null)
        {
            return Ok(new CheckAdhRestitutionResponseDto
            {
                Adherent = adherent,
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBy606CYdQuQNTxOH0mHl6Lxdker4OH8Nvvg&s"
            });
        }
        return Ok(new CheckAdhRestitutionResponseDto
        {
            Found = false
        });
    }

    [HttpPost]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreateAdherent([FromBody] Borrowing.SharedClasses.Requests.Adherent.CreateAdherentDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool success = await _adherentService.CreateAdherentAsync(dto);
        if (success)
            return Ok();

        return BadRequest("Impossible de creer l'adherent. Identifiant dejà existant ?");
    }

    [HttpPut]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateAdherent([FromBody] Borrowing.SharedClasses.Requests.Adherent.UpdateAdherentDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool success = await _adherentService.UpdateAdherentAsync(dto);
        if (success)
            return Ok();

        return NotFound("Adhérent introuvable ou erreur lors de la modification.");
    }

    [HttpGet("Stats")]
    public async Task<ActionResult> GetStats()
    {
        var result = await _adherentService.GetStats();
        return Ok(result);
    }

}