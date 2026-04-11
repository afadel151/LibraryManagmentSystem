using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace Borrowing.Api.Controllers;



[Route("MockAuth/[action]")]
public class MockAuthController : Controller
{
    private readonly IConfiguration _config;
    // In-memory mapping for idRequest -> compteUtilisateur (for mock; in production, use distributed cache or DB)
    private static readonly ConcurrentDictionary<string, string> _requestUserMapping = new();

    public MockAuthController(IConfiguration configuration)
    {
        _config = configuration;
    }

    [HttpGet]
    public IActionResult Login(string IdRequest)
    {
        // Retrieve prefilled username from mapping if available
        var prefilledUser = _requestUserMapping.TryGetValue(IdRequest ?? "", out var user) ? user : null;
        return Content(GetLoginHtml(IdRequest, null, prefilledUser), "text/html");
    }

    [HttpPost]
    public IActionResult Login(string IdRequest, string compteUtilisateur, string password)
    {
        // Optionally, fall back to mapping if posted username is empty (but allow override)
        if (string.IsNullOrEmpty(compteUtilisateur) && !string.IsNullOrEmpty(IdRequest))
        {
            _requestUserMapping.TryGetValue(IdRequest, out compteUtilisateur);
        }

        // Read hardcoded users from configuration (e.g., appsettings.json under "MockAuth:Users")
        // Example config: { "MockAuth": { "Users": { "admin": "securepass123", "user": "password456" } } }
        var usersSection = _config.GetSection("MockAuth:Users");
        var users = usersSection.Get<Dictionary<string, string>>();

        // Simulate login validation against config
        // In a real app, use hashed passwords (e.g., via IPasswordHasher) and additional checks like lockouts
        if (!string.IsNullOrEmpty(compteUtilisateur) &&
            !string.IsNullOrEmpty(password) &&
            users != null &&
            users.TryGetValue(compteUtilisateur, out var storedPassword) &&
            storedPassword == password) // Plain text for mock; hash in production
        {
            // Clean up mapping after successful login (optional, to avoid memory leaks)
            _requestUserMapping.TryRemove(IdRequest, out _);

            // Generate a mock token (in reality, use JWT or similar with expiration/claims)
            string token = "MOCK_TOKEN_" + compteUtilisateur + "_" + Guid.NewGuid().ToString("N")[..8];

            // Redirect back to the application's ResponseAuth with URL encoding
            var redirectUrl = $"/api/Auth/response?AuthToken={Uri.EscapeDataString(token)}";
            return Redirect(redirectUrl);
        }

        return Content(GetLoginHtml(IdRequest, "Identifiants invalides!", compteUtilisateur), "text/html");
    }

    private string GetLoginHtml(string idRequest, string error, string compteUtilisateur)
    {
        var errorHtml = string.IsNullOrEmpty(error) ? "" : $"<div style='color:red; margin-bottom: 10px;'>{error}</div>";
        return $@" 
                <html>
                <head>
                    <title>Mock Login</title>
                    <style>
                        body {{ font-family: sans-serif; display: flex; justify-content: center; align-items: center; height: 100vh; background-color: #f0f2f5; }}
                        .login-card {{ background: white; padding: 2rem; border-radius: 8px; box-shadow: 0 2px 4px rgba(0,0,0,0.1); width: 300px; }}
                        .form-group {{ margin-bottom: 1rem; }}
                        label {{ display: block; margin-bottom: 0.5rem; }}
                        input {{ width: 100%; padding: 0.5rem; border: 1px solid #ddd; border-radius: 4px; box-sizing: border-box; }}
                        button {{ width: 100%; padding: 0.75rem; background-color: #007bff; color: white; border: none; border-radius: 4px; cursor: pointer; }}
                        button:hover {{ background-color: #0056b3; }}
                    </style>
                </head>
                <body>
                    <div class='login-card'>
                        <h2 style='text-align:center; margin-top:0;'>Mock Auth</h2>
                        {errorHtml}
                        <form method='post' action='/MockAuth/Login'>
                            <input type='hidden' name='IdRequest' value='{idRequest}' />
                            <div class='form-group'>
                                <label>User:</label>
                                <input type='text' name='compteUtilisateur' value='{compteUtilisateur ?? ""}' />
                            </div>
                            <div class='form-group'>
                                <label>Password:</label>
                                <input type='password' name='password' value='' />
                            </div>
                            <button type='submit'>Login</button>
                        </form>
                    </div>
                </body>
                </html>";
    }

    [HttpGet]
    public IActionResult RequestAuth(string idApp, string key, string compteUtilisateur, string ipClient)
    {
        // In a more realistic mock, validate idApp and key against config
        // For now, simulate generating a request ID and map it to the provided compteUtilisateur
        string idRequest = Guid.NewGuid().ToString();
        if (!string.IsNullOrEmpty(compteUtilisateur))
        {
            _requestUserMapping[idRequest] = compteUtilisateur;
            // Optional: Set a TTL, e.g., via MemoryCache with expiration
        }
        return Ok(idRequest);
    }

    [HttpGet]
    public IActionResult CheckAuthToken(string idApp, string token)
    {
        ArgumentNullException.ThrowIfNull(token); 
        ArgumentNullException.ThrowIfNull(idApp); 
        // In reality, validate token signature/expiration
        if (token.StartsWith("MOCK_TOKEN_", StringComparison.OrdinalIgnoreCase))
        {
            // Extract username (in real JWT, parse claims)
            string compteUtilisateur = token.Replace("MOCK_TOKEN_", "", StringComparison.OrdinalIgnoreCase).Split('_')[0];
            return Ok(compteUtilisateur);
        }
        return BadRequest("Invalid token");
    }

    [HttpGet]
    public IActionResult Logout(string compteUtilisateur, string ipClient)
    {
        // In reality, invalidate token in cache/revocation list
        return Ok("LoggedOut");
    }
}

/// <summary>
/// Simulates an external authentication server.
/// Enabled when AuthSettings:UseMock = true in appsettings.json.
/// When you switch to the real auth server, this controller is simply ignored.
/// 
/// Flow:
///   1. AccountController calls GET /MockAuth/RequestAuth  → returns idRequest
///   2. AccountController redirects browser to GET /MockAuth/Login?IdRequest=...
///   3. User submits credentials → POST /MockAuth/Login validates against DB
///   4. On success, redirects to /Account/ResponseAuth?AuthToken=...
///   5. AccountController calls GET /MockAuth/CheckAuthToken → returns "compte|role"
/// </summary>