using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.SharedClasses.Responses.Position;
using Microsoft.AspNetCore.Authorization;

namespace Borrowing.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PositionController(IPositionService positionService) : ControllerBase
{
    private readonly IPositionService _positionService = positionService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PositionDto>>> GetAll()
    {
        var positions = await _positionService.GetAllPositionsAsync();
        return Ok(positions);
    }
}
