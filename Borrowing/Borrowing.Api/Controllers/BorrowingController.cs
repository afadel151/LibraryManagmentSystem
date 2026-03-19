using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Services;
using Borrowing.Api.DTOs;
using System.Threading.Tasks;

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
}