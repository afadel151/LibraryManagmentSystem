using System.Security.Claims;
using Common.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Inventory.Controllers;
public class AccountController : Controller
{
    private readonly IConfiguration _config;
    private readonly LibraryDbContext _db;

    private string AuthServer => _config.GetValue<bool>("AuthSettings:UseMock")
        ? $"{Request.Scheme}://{Request.Host}/MockAuth/"
        : _config["AuthSettings:ServerUrl"]!;

    private string IdApp  => _config["AuthSettings:idApp"]  ?? "CATLIB_CAT";
    private string KeyApp => _config["AuthSettings:keyApp"] ?? "AppKey";

    public AccountController(IConfiguration config, LibraryDbContext db)
    {
        _config = config;
        _db = db;
    }

    // GET /Account/Login — shows the login form (just a username field)
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    // POST /Account/Login — step 1: validate user exists, get requestId, redirect to mock server
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string compte, string? returnUrl = null)
    {
        var utilisateur = await _db.Utilisateurs
            .FirstOrDefaultAsync(u => u.Compte == compte);
        var admin = await _db.Admins
            .FirstOrDefaultAsync(a => a.IdAdmin == compte);

        if (utilisateur == null && admin == null)
        {
            ModelState.AddModelError("", "Compte introuvable.");
            return View();
        }

        // Store returnUrl in session so we can use it after the auth callback
        HttpContext.Session.SetString("returnUrl", returnUrl ?? "/");
        HttpContext.Session.SetString("compte", compte);

        using var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
        };
        using var http = new HttpClient(handler);

        var ipClient = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1";
        var authAddress = $"{AuthServer}RequestAuth?idApp={IdApp}&key={KeyApp}" +
                          $"&compteUtilisateur={compte}&ipClient={ipClient}";

        var response = await http.GetAsync(authAddress);
        var idRequest = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(idRequest))
        {
            ModelState.AddModelError("", "Erreur de communication avec le serveur d'authentification.");
            return View();
        }

        // Redirect the browser to the mock server login page — same as Blazor does
        var loginUrl = $"{AuthServer}Login?IdRequest={idRequest}";
        return Redirect(loginUrl);
    }

    // GET /Account/ResponseAuth — step 2: mock server redirects here with AuthToken
    // No JWT involved — we sign in with cookie auth directly
    [HttpGet]
    public async Task<IActionResult> ResponseAuth(string authToken)
    {
        using var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
        };

        string compte;
        using (var http = new HttpClient(handler))
        {
            var checkUrl = $"{AuthServer}CheckAuthToken?idApp={IdApp}&token={authToken}";
            var response = await http.GetAsync(checkUrl);

            if (!response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Login), new { error = "Token invalide" });

            compte = await response.Content.ReadAsStringAsync();
        }

        if (string.IsNullOrEmpty(compte))
            return RedirectToAction(nameof(Login), new { error = "Token invalide" });

        // Determine role — same logic as your Blazor API
        string role, nom;
        var admin = await _db.Admins.FirstOrDefaultAsync(a => a.IdAdmin == compte);
        if (admin != null)
        {
            role = "ADMIN";
            nom  = compte;
        }
        else
        {
            var utilisateur = await _db.Utilisateurs
                .FirstOrDefaultAsync(u => u.Compte == compte);

            if (utilisateur == null)
                return RedirectToAction(nameof(Login), new { error = "Compte non autorisé" });

            role = "UTILISATEUR";
            nom  = utilisateur.Nom ?? compte;
        }

        // Sign in with cookie auth — no JWT, no manual cookie, ASP.NET handles it
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name,   compte),
            new(ClaimTypes.Role,   role),
            new("nom",             nom),
        };

        var identity  = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties { IsPersistent = false }
        );

        var returnUrl = HttpContext.Session.GetString("returnUrl") ?? "/";
        HttpContext.Session.Remove("returnUrl");
        HttpContext.Session.Remove("compte");

        return LocalRedirect(returnUrl);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        var compte   = User.Identity?.Name ?? "";
        var ipClient = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1";

        using var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
        };
        using var http = new HttpClient(handler);
        await http.GetAsync($"{AuthServer}Logout?compteUtilisateur={compte}&ipClient={ipClient}");

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(Login));
    }
}