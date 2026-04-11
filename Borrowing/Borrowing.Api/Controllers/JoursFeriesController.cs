using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Requests.JoursFery;
using Borrowing.SharedClasses.Models;
using Microsoft.AspNetCore.Authorization;

namespace Borrowing.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class JoursFeriesController(IJoursFeriesService joursFeriesService) : ControllerBase
{
    private readonly IJoursFeriesService _joursFeriesService = joursFeriesService;

    [HttpGet]
    public async Task<ActionResult<PagedResult<JoursFeryDto>>> Get([FromQuery] PaginatedQueryParameters queryParameters)
    {
        var result = await _joursFeriesService.GetJoursFeriesAsync(queryParameters);
        return Ok(result);
    }

    [HttpGet("All")]
    public async Task<ActionResult<IEnumerable<JoursFeryDto>>> GetAll()
    {
        var result = await _joursFeriesService.GetAllJoursFeriesAsync();
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult<bool>> Create([FromBody] CreateJoursFeryDto dto)
    {
        var result = await _joursFeriesService.CreateJoursFeryAsync(dto);
        if (result)
        {
            return Ok(result);
        }
        return BadRequest("Jour férié already exists or creation failed.");
    }

    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult<bool>> Update([FromBody] UpdateJoursFeryDto dto)
    {
        var result = await _joursFeriesService.UpdateJoursFeryAsync(dto);
        if (result)
        {
            return Ok(result);
        }
        return NotFound("Jour férié not found.");
    }

    [HttpDelete("{dateJourFerie}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult<bool>> Delete(DateTime dateJourFerie)
    {
        var result = await _joursFeriesService.DeleteJoursFeryAsync(dateJourFerie);
        if (result)
        {
            return Ok(result);
        }
        return NotFound("Jour férié not found.");
    }
}