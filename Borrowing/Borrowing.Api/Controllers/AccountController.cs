using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;
using Borrowing.SharedClasses.Common;

namespace Borrowing.Api.Controllers
{
    [Route("Account/[action]")]
    public class AccountController(LibraryDbContext context) : Controller
    {
        private readonly LibraryDbContext _context = context; 

        [HttpPost]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Login(
            [FromBody]  LoginRequest request)
        {
            if (request == null)
                return BadRequest("La requête est invalide ou vide.");

            if (string.IsNullOrWhiteSpace(request.compte) || string.IsNullOrWhiteSpace(request.motdepasse))
                return BadRequest("Le compte et le mot de passe sont requis.");


            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.IdAdmin == request.compte && a.Password == request.motdepasse);


            var utilisateur = admin == null
                ? await _context.Utilisateurs
                    .FirstOrDefaultAsync(u => u.Compte == request.compte && u.Motdepasse == request.motdepasse)
                : null;
            if (admin == null && utilisateur == null)
            {
                var encodedError = Uri.EscapeDataString("Identifiants invalides !");
                return Unauthorized($"/Login?error={encodedError}");
            }

            var role = admin != null ? "Admin" : "Utilisateur";
            var nom  = admin != null ? admin.IdAdmin : (utilisateur!.Nom ?? request.compte);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name,       request.compte),
                new(ClaimTypes.Role,       role),
                new("Nom",                 nom),
            };

            var identity  = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc   = DateTimeOffset.UtcNow.AddHours(8)
                });
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

       
        [HttpPost]
        [Authorize]
        [IgnoreAntiforgeryToken]
        public IActionResult CurrentUser()
        {
            return Json(new
            {
                isAuthenticated = User.Identity?.IsAuthenticated ?? false,
                name            = User.Identity?.Name,
                role            = User.FindFirstValue(ClaimTypes.Role),
                nom             = User.FindFirstValue("Nom"),
            });
        }
    }
}