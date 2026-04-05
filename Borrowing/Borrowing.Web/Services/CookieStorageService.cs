using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.JSInterop;

namespace Borrowing.Web.Services;

public class CookieStorageService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IJSRuntime _js;

    public CookieStorageService(IHttpContextAccessor httpContextAccessor, IJSRuntime js)
    {
        _httpContextAccessor = httpContextAccessor;
        _js = js;
    }

    public async Task SetItemAsync(string key, string value, int expiryDays = 365)
    {
        var expiry = DateTimeOffset.UtcNow.AddDays(expiryDays).ToString("R");
        await _js.InvokeVoidAsync("eval",
            $"document.cookie='{key}={value}; path=/; expires={expiry}; SameSite=Strict'");
    }

     public async Task SetCultureAsync(string culture, int expiryDays = 365)
    {
        var expiry = DateTimeOffset.UtcNow.AddDays(expiryDays).ToString("R");
        var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture));
        await _js.InvokeVoidAsync("eval",
            $"document.cookie='culture={cookieValue}; path=/; expires={expiry}; SameSite=Strict'");
    }

    public Task<string?> GetItemAsync(string key)
    {
        var value = _httpContextAccessor.HttpContext?.Request.Cookies[key];
        return Task.FromResult(value);
    }

    public async Task RemoveItemAsync(string key)
    {
        await _js.InvokeVoidAsync("eval",
            $"document.cookie='{key}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;'");
    }
}