using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Borrowing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly LibraryDbContext _db;

        // Same pattern as AccountController.AUTH_SERVER
        private string? AuthServer => _config.GetValue<bool>("AuthSettings:UseMock")
            ? $"{Request.Scheme}://{Request.Host}/MockAuth/"
            : _config["AuthSettings:ServerUrl"];

        private string IdApp => _config["AuthSettings:idApp"] ?? "CATLIB_PRET";
        private string KeyApp => _config["AuthSettings:keyApp"] ?? "AppKey";

        public AuthController(IConfiguration config, LibraryDbContext db)
        {
            _config = config;
            _db = db;
        }

        // Step 1 — Blazor calls this first with the username
        // Returns the auth server login URL for Blazor to redirect the browser to
        [HttpGet("request")]
        public async Task<IActionResult> RequestAuth([FromQuery] string compte,
                                                     [FromQuery] string ipClient)
        {
            // Validate user exists in YOUR DB first (same as GetUserByCompteUtilisateur)
            var utilisateur = await _db.Utilisateurs
                .FirstOrDefaultAsync(u => u.Compte == compte);

            var admin = await _db.Admins
                .FirstOrDefaultAsync(a => a.IdAdmin == compte);

            if (utilisateur == null && admin == null)
                return NotFound("Compte introuvable dans la base de donnees.");

            // Ask auth server for a requestId
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
            };

            using var http = new HttpClient(handler);
            Console.WriteLine("#### authServer" + AuthServer);
            var authAddress = $"{AuthServer}RequestAuth?idApp={IdApp}&key={KeyApp}" +
                              $"&compteUtilisateur={compte}&ipClient={ipClient}";
            Console.WriteLine("#### authAdress" + authAddress);
            var response = await http.GetAsync(authAddress);
            Console.WriteLine("#### authAdress response" + response);
            var idRequest = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(idRequest))
                return StatusCode(502, "Erreur de communication avec le serveur d'authentification.");

            // Return the full auth server login URL — Blazor will navigate to it
            var loginUrl = $"{AuthServer}Login?IdRequest={idRequest}";
            return Ok(new { loginUrl });
        }

        // Step 2 — Auth server redirects browser here after successful login
        // This is a regular controller endpoint (not API JSON), it handles the redirect
        [HttpGet("response")]
        public async Task<IActionResult> ResponseAuth([FromQuery] string AuthToken)
        {
            // Verify token with auth server
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
            };

            string compte;
            using (var http = new HttpClient(handler))
            {
                var checkUrl = $"{AuthServer}CheckAuthToken?idApp={IdApp}&token={AuthToken}";
                var response = await http.GetAsync(checkUrl);

                if (!response.IsSuccessStatusCode)
                    return Redirect($"{GetBlazorBaseUrl()}/login?error=Token+invalide");

                compte = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[ResponseAuth] compte from token: '{compte}'");
            }

            if (string.IsNullOrEmpty(compte))
                return Redirect($"{GetBlazorBaseUrl()}/login?error=Token+invalide");

            // Find user in DB and determine role
            string role, nom;

            var admin = await _db.Admins
                .FirstOrDefaultAsync(a => a.IdAdmin == compte);
            Console.WriteLine($"[ResponseAuth] admin found: {admin != null}");
            if (admin != null)
            {
                role = "ADMIN";
                nom = compte;
            }
            else
            {
                var utilisateur = await _db.Utilisateurs
                    .FirstOrDefaultAsync(u => u.Compte == compte);
                Console.WriteLine($"[ResponseAuth] utilisateur found: {utilisateur != null}");
                if (utilisateur == null)
                    return Redirect($"{GetBlazorBaseUrl()}/login?error=Compte+non+autorise");

                role = "UTILISATEUR";
                nom = utilisateur.Nom ?? compte;
            }

            // Issue your own JWT — from here Blazor works normally with JWT
            var jwt = GenerateJwt(compte, role, nom);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = false,   // false so JS can read it if needed
                Secure = false,   // false for dev (http)
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddMinutes(_config.GetValue<int>("Jwt:ExpiresInMinutes"))
            };

            Response.Cookies.Append("authToken", jwt, cookieOptions);
            Response.Cookies.Append("userRole", role, cookieOptions);
            Response.Cookies.Append("userNom", Uri.EscapeDataString(nom ?? ""), cookieOptions);
            // Redirect to Blazor with JWT in query string (Blazor grabs it and stores it)
            return Redirect($"{GetBlazorBaseUrl()}/auth-callback");
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout([FromQuery] string compte,
                                                [FromQuery] string ipClient)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
            };

            using var http = new HttpClient(handler);
            var authAddress = $"{AuthServer}Logout?compteUtilisateur={compte}&ipClient={ipClient}";
            await http.GetAsync(authAddress); // fire and forget; logout locally regardless

            return Ok();
        }

        private string GenerateJwt(string compte, string role, string nom)
        {
            var key = new SymmetricSecurityKey(
                             Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, compte),
            new Claim(ClaimTypes.Role, role),
            new Claim("nom",           nom ?? ""),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                                        _config.GetValue<int>("Jwt:ExpiresInMinutes")),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Adjust this to your Blazor app's base URL
        private string GetBlazorBaseUrl() =>
            _config["BlazorApp:BaseUrl"] ?? $"{Request.Scheme}://{Request.Host}";
    }

}