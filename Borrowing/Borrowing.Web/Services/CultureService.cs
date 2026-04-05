using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Borrowing.Web.Services;

public class CultureService
{
    private static readonly HashSet<string> Supported = ["fr", "ar", "en"];

    private readonly CookieStorageService _cookieStorage;

    public event Action? OnCultureChanged;
    public string CurrentCulture { get; private set; } = "en";
    public bool IsRtl => CurrentCulture == "ar";

    public CultureService(CookieStorageService cookieStorage)
    {
        _cookieStorage = cookieStorage;

        // Read from cookie synchronously via HttpContext (available at construction time)
        var saved = _cookieStorage.GetItemAsync("culture").GetAwaiter().GetResult();
        if (!string.IsNullOrEmpty(saved))
        {
            var parsed = CookieRequestCultureProvider.ParseCookieValue(saved);
            var lang = parsed?.Cultures.FirstOrDefault().Value ?? saved;
            if (Supported.Contains(lang))
                CurrentCulture = lang;
        }

        ApplyCulture(CurrentCulture);
    }

    public async Task SetCultureAsync(string culture)
    {
        if (!Supported.Contains(culture)) return;
        CurrentCulture = culture;
        await _cookieStorage.SetCultureAsync(culture); // ← dedicated method
        ApplyCulture(culture);
        OnCultureChanged?.Invoke();
    }

    private static void ApplyCulture(string culture)
    {
        var ci = new CultureInfo(culture);
        CultureInfo.DefaultThreadCurrentCulture = ci;
        CultureInfo.DefaultThreadCurrentUICulture = ci;
    }
}