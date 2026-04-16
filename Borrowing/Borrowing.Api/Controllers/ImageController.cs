using Borrowing.Api.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace Borrowing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController(IConfiguration configuration,ILogger<ImageController> logger) : ControllerBase
{
    private readonly ILogger<ImageController> _logger = logger;
    private readonly string? _appKey = configuration.GetValue<string>("ImageSettings:AppKey");
    private readonly string? _initialVector = configuration.GetValue<string>("ImageSettings:InitialVector");

    [HttpGet("SmallByMatricule/{encrypted}")]
    public async Task<IActionResult> GetSmallByMatricule(string encrypted)
    {
        try
        {
            var matricule = BaseExtensions.DecryptString(encrypted, _appKey!, _initialVector!);
            _logger.LogInformation("Matricule : " + matricule);
            var path = Path.Combine("MockStorage/images", $"{matricule}.png");
            _logger.LogInformation("Path : " + path);

            if (!System.IO.File.Exists(path))
                path = Path.Combine("MockStorage/images", "default.png");

            var bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "image/png");
        }
        catch
        {
            return NotFound();
        }
    }
}
