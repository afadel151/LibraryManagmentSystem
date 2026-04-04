using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;
using Borrowing.SharedClasses.Common.User;
namespace Borrowing.Web.Services;

public class CookieAuthStateProvider(IHttpClientFactory httpClientFactory) : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("BorrowingApi");

    // cache state
    private AuthenticationState? _cachedState;

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (_cachedState != null)
            return _cachedState;

        try
        {
            // call  API 
            var response = await _httpClient.PostAsync("Account/CurrentUser", null);

            if (!response.IsSuccessStatusCode)
            {
                _cachedState = Anonymous();
                return _cachedState;
            }

            var userInfo = await response.Content.ReadFromJsonAsync<CurrentUserResponseDto>();

            if (userInfo == null || !userInfo.IsAuthenticated)
            {
                _cachedState = Anonymous();
                return _cachedState;
            }
            var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, userInfo.Name ?? ""),
                    new(ClaimTypes.Role, userInfo.Role ?? ""),
                    new("Nom",           userInfo.Nom  ?? ""),
                };

            var identity = new ClaimsIdentity(claims, "CookieAuth", ClaimTypes.Name, ClaimTypes.Role);
            var principal = new ClaimsPrincipal(identity);

            _cachedState = new AuthenticationState(principal);
            return _cachedState;
        }
        catch
        {
            _cachedState = Anonymous();
            return _cachedState;
        }
    }


    public void NotifyStateChanged()
    {
        _cachedState = null;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private static AuthenticationState Anonymous()
    {
        var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        return new AuthenticationState(anonymous);
    }

}
