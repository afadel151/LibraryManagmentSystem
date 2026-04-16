using Borrowing.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Borrowing.Web.Providers;

public class JwtAuthStateProvider(IHttpContextAccessor httpContextAccessor) : AuthenticationStateProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    private static readonly AuthenticationState Anonymous =
        new(new ClaimsPrincipal(new ClaimsIdentity()));

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Synchronous — no JS interop needed, reads from HTTP cookie
        var token = _httpContextAccessor.HttpContext?.Request.Cookies["authToken"];

        Console.WriteLine($"[JwtAuthStateProvider] token from cookie: '{token?[..Math.Min(20, token?.Length ?? 0)]}...'");

        if (string.IsNullOrEmpty(token) || IsTokenExpired(token))
            return Task.FromResult(Anonymous);

        var claims = ParseClaimsFromJwt(token);
        var identity = new ClaimsIdentity(claims, "jwt");

        Console.WriteLine($"[JwtAuthStateProvider] authenticated as: {identity.Name}");

        return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }

    public void NotifyAuthStateChanged() =>
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

    private bool IsTokenExpired(string token)
    {
        try
        {
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            return jwt.ValidTo < DateTime.UtcNow;
        }
        catch (Exception ex) { return true; }
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string token)
    {
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
        return jwt.Claims;
    }
}