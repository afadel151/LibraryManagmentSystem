
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Borrowing.Api.Services.Cache;

// not in use
public interface IJoursFeriesCacheService
{
    bool TryGet<T>(out T? value);
    void Set<T>(T value);
    void Invalidate();


}
public class JoursFeriesCacheService
{
    private readonly IMemoryCache _cache;
    private readonly Dictionary<string, CancellationTokenSource> _tokens = new();
    private static readonly string[] SupportedLanguages = ["fr", "en", "ar"];

    public JoursFeriesCacheService(IMemoryCache cache)
    {
        _cache = cache;
        foreach (var lang in SupportedLanguages)
            _tokens[lang] = new CancellationTokenSource();
    }

    private static string Key(string lang) => $"JoursFeries_Enriched_{lang}";

    public bool TryGet<T>(string lang, out T? value) =>
        _cache.TryGetValue(Key(lang), out value);

    public void Set<T>(string lang, T value)
    {
        var options = new MemoryCacheEntryOptions()
            .AddExpirationToken(new CancellationChangeToken(_tokens[lang].Token));
        _cache.Set(Key(lang), value, options);
    }

    public void InvalidateAll()
    {
        foreach (var lang in SupportedLanguages)
        {
            _tokens[lang].Cancel();
            _tokens[lang].Dispose();
            _tokens[lang] = new CancellationTokenSource();
        }
    }
}