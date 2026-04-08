using Microsoft.AspNetCore.Mvc;
using Borrowing.Api.Repositories;
using Borrowing.SharedClasses.Responses.Adherent;

namespace Borrowing.Api.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("api/[controller]")]
public class EtatAdherentController(IEtatAdherentRepository etatAdherentRepository) : ControllerBase
{
    private readonly IEtatAdherentRepository _etatAdherentRepository = etatAdherentRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EtatAdherentDto>>> Get()
    {
        var etats = await _etatAdherentRepository.GetAllAsync();
        return Ok(etats.Select(e => new EtatAdherentDto
        {
            IdEtat = e.IdEtat,
            DescEtat = e.DescEtat ?? string.Empty
        }));
    }
}
