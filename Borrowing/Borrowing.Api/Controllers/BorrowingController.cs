using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.Shared.Requests.Pret;
using Borrowing.Shared.Responses.Pret;
namespace Borrowing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowingController : ControllerBase
{
    private readonly IPretService _pretService;

    public BorrowingController(IPretService pretService)
    {
        _pretService = pretService;
    }
    
    [HttpGet]
    public async Task<ActionResult<PagedResult<PretResponseDto>>> Get([FromQuery] PretQueryParameters queryParameters)
    {
        var result = await _pretService.GetPretsAsync(queryParameters);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreatePretResponseDto>> CreatePret([FromBody] CreatePretRequestDTo pretRequestDto)
    {
        var result = await _pretService.CreatePretAsync(pretRequestDto);
        return Ok(result);
    }

    
}