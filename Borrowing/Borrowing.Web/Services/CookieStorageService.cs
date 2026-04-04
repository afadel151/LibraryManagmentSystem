using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;

namespace Borrowing.Web.Services;

public class CookieStorageService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IJSRuntime? _js;

    public CookieStorageService(IHttpContextAccessor httpContextAccessor, IJSRuntime js)
    {
        _httpContextAccessor = httpContextAccessor;
        _js = js;
    }

    public async Task SetItemAsync(string key, string value)
    {
        // Write via JS on client side
        await _js!.InvokeVoidAsync("document.cookie", 
            $"{key}={value}; path=/; SameSite=Strict");
    }

    public Task<string?> GetItemAsync(string key)
    {
        // During SSR — read from HttpContext cookies (available server-side)
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext != null)
        {
            var value = httpContext.Request.Cookies[key];
            return Task.FromResult(value);
        }
        return Task.FromResult<string?>(null);
    }

    public async Task RemoveItemAsync(string key)
    {
        await _js!.InvokeVoidAsync("eval", 
            $"document.cookie='{key}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;'");
    }
}