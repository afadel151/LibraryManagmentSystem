using System.Net.Http.Headers;
using Borrowing.Web.Providers;
using Microsoft.AspNetCore.Components;
namespace Borrowing.Web.Services;

public class AuthService(IHttpClientFactory factory, CookieStorageService storage, NavigationManager nav,JwtAuthStateProvider authStateProvider)
{
    private readonly HttpClient _http = factory.CreateClient("BorrowingApi");
    private readonly CookieStorageService _storage = storage;
    private readonly NavigationManager _nav = nav;
    private readonly JwtAuthStateProvider _authStateProvider = authStateProvider;
    public string? CurrentRole { get; private set; }
    public string? CurrentNom { get; private set; }
    public bool IsLoggedIn => !string.IsNullOrEmpty(CurrentRole);

    // Step 1: Blazor calls this — gets auth server URL and navigates the browser there
    public async Task StartLoginAsync(string compte)
    {
        var ipClient = "0.0.0.0"; // optionally detect client IP
        var response = await _http.GetAsync(
            $"api/Auth/request?compte={Uri.EscapeDataString(compte)}&ipClient={ipClient}");

        if (!response.IsSuccessStatusCode)
        {
            // handle error — read message and show to user
            return;
        }

        var result = await response.Content.ReadFromJsonAsync<RequestAuthResult>();

        // This causes the browser to leave Blazor and go to the auth server login page
        _nav.NavigateTo(result!.LoginUrl, forceLoad: true);
    }

    // Step 2: Called by /auth-callback page after WebAPI redirects back with JWT
    public async Task FinalizeLoginAsync(string token, string role, string nom)
    {
        await _storage.SetItemAsync("authToken", token);
        await _storage.SetItemAsync("userRole", role);
        await _storage.SetItemAsync("userNom", nom);

        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        _authStateProvider.NotifyAuthStateChanged(); // ← tell Blazor auth state changed
    }

    public async Task LogoutAsync(string compte)
    {
        await _http.GetAsync(
            $"api/auth/logout?compte={Uri.EscapeDataString(compte)}&ipClient=0.0.0.0");

        await _storage.RemoveItemAsync("authToken");
        await _storage.RemoveItemAsync("userRole");
        await _storage.RemoveItemAsync("userNom");

        CurrentRole = null;
        CurrentNom = null;
        _http.DefaultRequestHeaders.Authorization = null;
        _authStateProvider.NotifyAuthStateChanged();
        _nav.NavigateTo("/login", forceLoad: true);
    }

    public async Task InitializeAsync()
    {
        var token = await _storage.GetItemAsync("authToken");
        if (!string.IsNullOrEmpty(token))
        {
            CurrentRole = await _storage.GetItemAsync("userRole");
            CurrentNom = await _storage.GetItemAsync("userNom");
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }

    private class RequestAuthResult { public string? LoginUrl { get; set; } }
}