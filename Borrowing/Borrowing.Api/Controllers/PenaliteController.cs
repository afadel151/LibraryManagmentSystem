using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.Penalite;
using Borrowing.SharedClasses.Common;
using Microsoft.AspNetCore.Authorization;

namespace Borrowing.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PenaliteController(IPenaliteService penaliteService) : ControllerBase
{
    private readonly IPenaliteService _penaliteService = penaliteService;

    [HttpGet]
    public async Task<ActionResult<PagedResult<PenaliteDto>>> Get([FromQuery] PaginatedQueryParameters queryParameters)
    {
        var result = await _penaliteService.GetPenalitesAsync(queryParameters);
        return Ok(result);
    }

    [HttpGet("All")]
    public async Task<ActionResult<IEnumerable<PenaliteDto>>> GetAll()
    {
        var result = await _penaliteService.GetAllPenalitesAsync();
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult<bool>> Create([FromBody] CreatePenaliteDto dto)
    {
        var result = await _penaliteService.CreatePenaliteAsync(dto);
        if (result)
        {
            return Ok(result);
        }
        return BadRequest("Pénalité already exists or creation failed.");
    }

    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult<bool>> Update([FromBody] UpdatePenaliteDto dto)
    {
        var result = await _penaliteService.UpdatePenaliteAsync(dto);
        if (result)
        {
            return Ok(result);
        }
        return NotFound("Pénalité not found.");
    }

    [HttpDelete("{idCategorie}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult<bool>> Delete(string idCategorie)
    {
        var result = await _penaliteService.DeletePenaliteAsync(idCategorie);
        if (result)
        {
            return Ok(result);
        }
        return NotFound("Pénalité not found.");
    }
}